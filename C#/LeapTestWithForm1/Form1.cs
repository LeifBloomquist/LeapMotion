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

        System.Drawing.Graphics graphicsObj = null;
        Pen redPen = new Pen(System.Drawing.Color.Red, 5);
        Pen yellowPen = new Pen(System.Drawing.Color.Yellow, 5);

        float tempx, tempy, tempz;

        FixedSizedQueue<float> xhistory = new FixedSizedQueue<float>(100);
        FixedSizedQueue<float> yhistory = new FixedSizedQueue<float>(100);

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
            LeapLabel.Text = leap.GetInfo();
            Animate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Animate();
        }

        private void Animate2()
        {
            if (graphicsObj == null) return;

            graphicsObj.Clear(Color.Black);

            float mx = (pictureBox1.Width / 2f) + leap.X;
            float my = (pictureBox1.Height / 2f) - leap.Y;
            float size = 200+leap.Z;
           
            graphicsObj.DrawEllipse(redPen, mx, my, size, size);
        }

        private void Animate1()
        {
            if (graphicsObj == null) return;
            graphicsObj.Clear(Color.Black);

            tempx += (leap.velX / 10f);
            tempy -= (leap.velY / 10f);
            tempz += (leap.velZ / 10f);

            graphicsObj.DrawEllipse(redPen, tempx, tempy, tempz, tempz);
        }



        private void Animate()
        {
            if (graphicsObj == null) return;

            graphicsObj.Clear(Color.Black);

            float mx = (pictureBox1.Width / 2f) + leap.velX;
            float my = (pictureBox1.Height / 2f) - leap.velY;
            float size = 5; // 200 - leap.pinch * 100f;

            xhistory.Enqueue(mx);
            yhistory.Enqueue(my);
            float avex = xhistory.Average();
            float avey = yhistory.Average();

            float kx = (float)kal_x.update(mx);
            float ky = (float)kal_y.update(my);

            graphicsObj.DrawEllipse(redPen, avex, avey, size, size);
            graphicsObj.DrawEllipse(yellowPen, kx, ky, size, size);

            Directions();
        }

        private void Directions()
        {
            float threshold = 100f;

            bool up = false, down = false, left = false, right = false, fire = false;

            if (leap.velX < -threshold) left = true;
            if (leap.velX > +threshold) right = true;
            if (leap.velY < -threshold) down = true;
            if (leap.velY > +threshold) up = true;
            if (leap.pinch > +0.95) fire = true;

            toggle(Up, up);
            toggle(Down, down);
            toggle(Left, left);
            toggle(Right, right);
            toggle(Fire, fire, Color.Red);
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
