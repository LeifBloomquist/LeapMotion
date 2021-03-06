﻿using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace LeapMIDI
{
    public partial class MainForm : Form
    {
        LeapStuff leap = new LeapStuff();
        MIDIHandler midi = MIDIHandler.Instance;

        System.Drawing.Graphics graphicsObj = null;
        Pen redPen = new Pen(System.Drawing.Color.Red, 5);
        Pen yellowPen = new Pen(System.Drawing.Color.Yellow, 5);

        SimpleKalman kal_x = new SimpleKalman();
        SimpleKalman kal_y = new SimpleKalman();

        public MainForm()
        {
            InitializeComponent();
            midi.InitializeMIDI();

            graphicsObj = pictureBox1.CreateGraphics();

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
          DoMIDI();
        }

        private void Animate()
        {
            if (graphicsObj == null) return;

            graphicsObj.Clear(Color.Black);

            // Position

            float px = (pictureBox1.Width / 2f) + leap.posX;
            float py = (pictureBox1.Height) - leap.posY;
            float psize = 50 + (leap.posZ);
            try
            {
                graphicsObj.DrawEllipse(redPen, px, py, psize, psize);
            }
            catch { }

            // Motion

            float mx = (pictureBox1.Width / 2f) + leap.velX;
            float my = (pictureBox1.Height / 2f) - leap.velY;
            float msize = 5 + (leap.pinch * 10f);

            float kx = (float)kal_x.update(mx);
            float ky = (float)kal_y.update(my);

            graphicsObj.DrawEllipse(yellowPen, kx, ky, msize, msize);          
        }

        private void DoMIDI()
        {
            float threshold = 400f;

            float vel_temp = leap.velX*leap.velX + leap.velY*leap.velY + leap.velZ*leap.velZ;
            float velocity = (float)Math.Sqrt((double)vel_temp);

            int modx = midi.ValueToMIDI(leap.posX, -200, 200);
            int mody = midi.ValueToMIDI(leap.posY, 0, 500);
            int modz = midi.ValueToMIDI(leap.posZ, -200, 200);
            int pinch = midi.ValueToMIDI(leap.pinch , 0f, 1f);

            midi.SendMIDI(ChannelCommand.Controller, 0, 1, modx);
            midi.SendMIDI(ChannelCommand.Controller, 0, 2, mody);
            midi.SendMIDI(ChannelCommand.Controller, 0, 3, modz);
            midi.SendMIDI(ChannelCommand.Controller, 0, 4, pinch);

            if (false) // velocity >= threshold)
            {
               int note = midi.ValueToMIDI(leap.posX, -250, +300);
               int vel = midi.ValueToMIDI(velocity, 200, 800);

               midi.SendMIDI(ChannelCommand.NoteOn, 0, note, vel);
               Thread.Sleep(50);
               midi.SendMIDI(ChannelCommand.NoteOff, 0, note, 127);
            }


//            if (leap.pinch > +0.50) fire = true;

        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
          Animate();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
          Environment.Exit(0);
        }
    }
}
