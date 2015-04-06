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

namespace LeapTestWithForm1
{
    public partial class Form1 : Form
    {
        LeapStuff leap = new LeapStuff();
        SerialStuff serial = new SerialStuff("COM10");

        System.Drawing.Graphics graphicsObj = null;
        Pen redPen = new Pen(System.Drawing.Color.Red, 5);
        Pen yellowPen = new Pen(System.Drawing.Color.Yellow, 5);

        float tempx, tempy, tempz;

        SimpleKalman kal_x = new SimpleKalman();
        SimpleKalman kal_y = new SimpleKalman();

        public Form1()
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
            Animate();
            Directions();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Animate();           
        }

        private void Animate()
        {
            if (graphicsObj == null) return;

            graphicsObj.Clear(Color.Black);

            // Position

            float px = (pictureBox1.Width / 2f) + leap.posX;
            float py = (pictureBox1.Height) - leap.posY;
            float psize = 50 + (leap.posZ);
            graphicsObj.DrawEllipse(redPen, px, py, psize, psize);

            // Motion

            float mx = (pictureBox1.Width / 2f) + leap.velX;
            float my = (pictureBox1.Height / 2f) - leap.velY;
            float msize = 5 + (leap.pinch * 10f);

            float kx = (float)kal_x.update(mx);
            float ky = (float)kal_y.update(my);

            graphicsObj.DrawEllipse(yellowPen, kx, ky, msize, msize);

          
        }

        private void Directions()
        {
            float threshold = 200f;

            bool up = false, down = false, left = false, right = false, fire = false;

            if (leap.velX < -threshold) left = true;
            if (leap.velX > +threshold) right = true;
            if (leap.velY < -threshold) down = true;
            if (leap.velY > +threshold) up = true;
            if (leap.pinch > +0.50) fire = true;

            toggle(Up, up);
            toggle(Down, down);
            toggle(Left, left);
            toggle(Right, right);
            toggle(Fire, fire, Color.Red);

            SerialSend(up, down, left, right, fire);
        }

        private void SerialSend(bool up, bool down, bool left, bool right, bool fire)
        {
            byte b = 0xFF;
 
            if (up)    { b &= 0xFE; }
            if (down)  { b &= 0xFD; }
            if (left)  { b &= 0xFB; }
            if (right) { b &= 0xF7; }
            if (fire)  { b &= 0xEF; }

            serial.sendByte(b);
            SerialLabel.Text = "Sending: " + b;
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
    }
}
