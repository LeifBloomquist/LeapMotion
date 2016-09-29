using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace LeapUniJoysticle
{
     struct motions
     {
       
     }

    public partial class MainForm : Form
    {
        LeapStuff leap = new LeapStuff();
        NetworkStuff udp = new NetworkStuff("192.168.4.1", 6464);

        System.Drawing.Graphics graphicsObj = null;
        Pen whitePen = new Pen(System.Drawing.Color.White, 5);
        Pen redPen = new Pen(System.Drawing.Color.Red, 5);
        Pen yellowPen = new Pen(System.Drawing.Color.Yellow, 5);
        Pen greenPen = new Pen(System.Drawing.Color.Green, 5);
        Pen bluePen = new Pen(System.Drawing.Color.LightBlue, 5);

        byte activePort = 0;

        float tempx, tempy, tempz;

        SimpleKalman kal_x = new SimpleKalman();
        SimpleKalman kal_y = new SimpleKalman();

        public MainForm()
        {
            InitializeComponent();

            graphicsObj = pictureBox1.CreateGraphics();

            tempx = (pictureBox1.Width / 2f);
            tempy = (pictureBox1.Height / 2f);
            tempz = 100f;

            System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();            
            aTimer.Tick += new EventHandler(OnTimedEvent);
            aTimer.Interval=10;
            aTimer.Enabled=true;
        }   

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, EventArgs e)
        {
            leap.Update();
            LeapLabel.Text = leap.info;
            Hand0InfoLabel.Text = leap.hands[0].info;
            Hand1InfoLabel.Text = leap.hands[1].info;

            Animate();
            DoJoystick();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Animate();           
        }

        private void Animate()
        {
          if (graphicsObj == null) return;
          graphicsObj.Clear(Color.Black);

          Pen pos_pen = whitePen;
          Pen vel_pen = whitePen;

          foreach (myHand hand in leap.hands)
          {
            if (hand.isLeft)
            {
              pos_pen = redPen;
              vel_pen = yellowPen;
            }
            else if (hand.isRight)
            {
              pos_pen = greenPen;
              vel_pen = bluePen;
            }
            else // ?
            {
              return;
            }

            // Position

            float px = (pictureBox1.Width / 2f) + hand.posX;
            float py = (pictureBox1.Height) - hand.posY;
            float psize = 50 + (hand.posZ);
            try
            {
              graphicsObj.DrawEllipse(pos_pen, px, py, psize, psize);
            }
            catch { }

            // Motion

            float mx = (pictureBox1.Width / 2f) + hand.velX;
            float my = (pictureBox1.Height / 2f) - hand.velY;
            float msize = 5 + (hand.pinch * 10f);

            float kx = (float)kal_x.update(mx);
            float ky = (float)kal_y.update(my);

            graphicsObj.DrawEllipse(vel_pen, kx, ky, msize, msize);
          }
        }

        private void DoJoystick()
        {
          if (udp == null)
          {
            return;
          }
                    
          var motion = new byte[2] {0,0};

          if (activePort == 1)
          {
            if (leap.numHands == 1)
            {
              motion[0] = getMotions(leap.hands[0]);
            }
            else
            {
              motion[0] = 0;
            }             
          }
          else if (activePort == 2)
          {
            if (leap.numHands == 1)
            {
              motion[1] = getMotions(leap.hands[0]);                
            }
            else
            {
              motion[1] = 0;
            }              
          }

          else if (activePort == 3)
          {
            if (leap.numHands == 0)
            {
              motion[0] = 0;
              motion[1] = 0;
            }
            if (leap.numHands == 1)
            {
              if (leap.hands[0].isLeft)
              {
                motion[0] = getMotions(leap.hands[0]);
                motion[1] = 0;
              }
              else if (leap.hands[0].isRight)
              {
                motion[0] = 0;
                motion[1] = getMotions(leap.hands[0]);
              }  
              else
              {
                motion[0] = 0;
                motion[1] = 0;
              }
            }
            else if (leap.numHands == 2)
            {
              motion[0] = getMotions(leap.hands[0]);  // Always leftmost
              motion[1] = getMotions(leap.hands[1]);  // Always rightmost
            }
            else
            {
              motion[0] = 0;
              motion[1] = 0;
            }
          }
          else  // Invalid config.
          {
            return;
          }

          /*
          // UniJoysticle Protocol V1
          byte[] packet = new byte[2];
          packet[0] = (byte)hand.which;
          packet[1] = motion;
          udp.sendData(packet);          
           */
          
          // UniJoysticle Protocol V2
          byte[] packet = new byte[4];
          packet[0] = 2;                 // V2
          packet[1] = activePort; 
          packet[2] = motion[0];
          packet[3] = motion[1];
          udp.sendData(packet);

          SerialLabel.Text = "Sending: " + BitConverter.ToString(packet);
        }

        
        private byte getMotions(myHand hand)
        {
          const float threshold = 200f;

          byte temp=0;
          bool up = false, down = false, left = false, right = false, fire = false;

          if (hand.velX < -threshold) left = true;
          if (hand.velX > +threshold) right = true;
          if (hand.velY < -threshold) down = true;
          if (hand.velY > +threshold) up = true;
          if (hand.pinch > +0.70) fire = true;

          toggle(Up, up);
          toggle(Down, down);
          toggle(Left, left);
          toggle(Right, right);
          toggle(Fire, fire, Color.Red);

          if (up) temp |= 0x01;
          if (down) temp |= 0x02;
          if (left) temp |= 0x04;
          if (right) temp |= 0x08;
          if (fire) temp |= 0x10;

          return temp;
        }


        private void toggle(Control c, Boolean state, Color color)
        {
            if (state)
            {
                c.BackColor = color;
            }
            else
            {
                c.BackColor = Color.Black;
            }
        }

        private void toggle(Control c, Boolean state)
        {
            toggle(c, state, Color.Green);
        }

        private void JoystickPort1Button_Click(object sender, EventArgs e)
        {
          activePort = 1;
          UpdateModeButtons();
        }

        private void JoystickPort2Button_Click(object sender, EventArgs e)
        {
          activePort = 2;
          UpdateModeButtons();
        }

        private void JoystickBothPortsButton_Click(object sender, EventArgs e)
        {
          activePort = 3;
          UpdateModeButtons();
        }

        private void UpdateModeButtons()
        {
            switch (activePort)
            {
              case 0: 
                JoystickPort1Button.BackColor = SystemColors.Control;
                JoystickPort2Button.BackColor = SystemColors.Control;
                JoystickBothPortsButton.BackColor = SystemColors.Control;
                break;

              case 1:
                JoystickPort1Button.BackColor = Color.LightGreen;
                JoystickPort2Button.BackColor = SystemColors.Control;
                JoystickBothPortsButton.BackColor = SystemColors.Control;
                break;

              case 2:
                JoystickPort1Button.BackColor = SystemColors.Control;
                JoystickPort2Button.BackColor = Color.LightGreen;
                JoystickBothPortsButton.BackColor = SystemColors.Control;
                break;

              case 3:
                JoystickPort1Button.BackColor = SystemColors.Control;
                JoystickPort2Button.BackColor = SystemColors.Control;
                JoystickBothPortsButton.BackColor = Color.LightGreen;
                break;

              default:
                JoystickPort1Button.BackColor = Color.Red;
                JoystickPort2Button.BackColor = Color.Red;
                JoystickBothPortsButton.BackColor = Color.Red;
                break;
            }
        }
    }
}
