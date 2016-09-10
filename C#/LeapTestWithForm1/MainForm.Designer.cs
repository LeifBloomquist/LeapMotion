namespace LeapTestWithForm1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LeapLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Up = new System.Windows.Forms.Label();
            this.Down = new System.Windows.Forms.Label();
            this.Left = new System.Windows.Forms.Label();
            this.Right = new System.Windows.Forms.Label();
            this.Fire = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.PortName = new System.Windows.Forms.ToolStripStatusLabel();
            this.SerialLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Joystick = new System.Windows.Forms.GroupBox();
            this.PaddleModeButton = new System.Windows.Forms.Button();
            this.JoystickModeButton = new System.Windows.Forms.Button();
            this.MouseModeButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PaddleLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MouseLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Joystick.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeapLabel
            // 
            this.LeapLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LeapLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeapLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeapLabel.Location = new System.Drawing.Point(12, 16);
            this.LeapLabel.Name = "LeapLabel";
            this.LeapLabel.Size = new System.Drawing.Size(245, 186);
            this.LeapLabel.TabIndex = 0;
            this.LeapLabel.Text = "Info";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(918, 417);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Up
            // 
            this.Up.BackColor = System.Drawing.Color.Black;
            this.Up.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Up.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Up.ForeColor = System.Drawing.Color.White;
            this.Up.Location = new System.Drawing.Point(77, 20);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(53, 23);
            this.Up.TabIndex = 2;
            this.Up.Text = "Up";
            this.Up.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Down
            // 
            this.Down.BackColor = System.Drawing.Color.Black;
            this.Down.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Down.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Down.ForeColor = System.Drawing.Color.White;
            this.Down.Location = new System.Drawing.Point(77, 78);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(53, 23);
            this.Down.TabIndex = 3;
            this.Down.Text = "Down";
            this.Down.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Left
            // 
            this.Left.BackColor = System.Drawing.Color.Black;
            this.Left.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Left.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Left.ForeColor = System.Drawing.Color.White;
            this.Left.Location = new System.Drawing.Point(18, 49);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(53, 23);
            this.Left.TabIndex = 4;
            this.Left.Text = "Left";
            this.Left.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Right
            // 
            this.Right.BackColor = System.Drawing.Color.Black;
            this.Right.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Right.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Right.ForeColor = System.Drawing.Color.White;
            this.Right.Location = new System.Drawing.Point(136, 49);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(53, 23);
            this.Right.TabIndex = 5;
            this.Right.Text = "Right";
            this.Right.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Fire
            // 
            this.Fire.BackColor = System.Drawing.Color.Black;
            this.Fire.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Fire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Fire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fire.ForeColor = System.Drawing.Color.White;
            this.Fire.Location = new System.Drawing.Point(77, 49);
            this.Fire.Name = "Fire";
            this.Fire.Size = new System.Drawing.Size(53, 23);
            this.Fire.TabIndex = 6;
            this.Fire.Text = "Fire";
            this.Fire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PortName,
            this.SerialLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 662);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(918, 24);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // PortName
            // 
            this.PortName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.PortName.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.PortName.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PortName.Name = "PortName";
            this.PortName.Padding = new System.Windows.Forms.Padding(100, 0, 0, 0);
            this.PortName.Size = new System.Drawing.Size(126, 19);
            this.PortName.Text = "---";
            this.PortName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SerialLabel
            // 
            this.SerialLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.SerialLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.SerialLabel.Name = "SerialLabel";
            this.SerialLabel.Padding = new System.Windows.Forms.Padding(200, 0, 0, 0);
            this.SerialLabel.Size = new System.Drawing.Size(226, 19);
            this.SerialLabel.Text = "---";
            this.SerialLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LeapLabel);
            this.groupBox1.Location = new System.Drawing.Point(10, 420);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 216);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // Joystick
            // 
            this.Joystick.Controls.Add(this.Right);
            this.Joystick.Controls.Add(this.Up);
            this.Joystick.Controls.Add(this.Down);
            this.Joystick.Controls.Add(this.Fire);
            this.Joystick.Controls.Add(this.Left);
            this.Joystick.Location = new System.Drawing.Point(279, 471);
            this.Joystick.Name = "Joystick";
            this.Joystick.Size = new System.Drawing.Size(214, 116);
            this.Joystick.TabIndex = 9;
            this.Joystick.TabStop = false;
            this.Joystick.Text = "Joystick";
            // 
            // PaddleModeButton
            // 
            this.PaddleModeButton.Location = new System.Drawing.Point(499, 424);
            this.PaddleModeButton.Name = "PaddleModeButton";
            this.PaddleModeButton.Size = new System.Drawing.Size(200, 41);
            this.PaddleModeButton.TabIndex = 10;
            this.PaddleModeButton.Text = "Paddle Mode";
            this.PaddleModeButton.UseVisualStyleBackColor = true;
            this.PaddleModeButton.Click += new System.EventHandler(this.PaddleModeButton_Click);
            // 
            // JoystickModeButton
            // 
            this.JoystickModeButton.Location = new System.Drawing.Point(279, 424);
            this.JoystickModeButton.Name = "JoystickModeButton";
            this.JoystickModeButton.Size = new System.Drawing.Size(214, 41);
            this.JoystickModeButton.TabIndex = 11;
            this.JoystickModeButton.Text = "Joystick Mode";
            this.JoystickModeButton.UseVisualStyleBackColor = true;
            this.JoystickModeButton.Click += new System.EventHandler(this.JoystickModeButton_Click);
            // 
            // MouseModeButton
            // 
            this.MouseModeButton.Location = new System.Drawing.Point(706, 424);
            this.MouseModeButton.Name = "MouseModeButton";
            this.MouseModeButton.Size = new System.Drawing.Size(200, 41);
            this.MouseModeButton.TabIndex = 12;
            this.MouseModeButton.Text = "1351 Mouse Mode";
            this.MouseModeButton.UseVisualStyleBackColor = true;
            this.MouseModeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PaddleLabel);
            this.groupBox2.Location = new System.Drawing.Point(499, 471);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 116);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paddle";
            // 
            // PaddleLabel
            // 
            this.PaddleLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaddleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PaddleLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaddleLabel.Location = new System.Drawing.Point(6, 16);
            this.PaddleLabel.Name = "PaddleLabel";
            this.PaddleLabel.Size = new System.Drawing.Size(189, 85);
            this.PaddleLabel.TabIndex = 1;
            this.PaddleLabel.Text = "--";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MouseLabel);
            this.groupBox3.Location = new System.Drawing.Point(706, 471);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(201, 116);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mouse";
            // 
            // MouseLabel
            // 
            this.MouseLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MouseLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MouseLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MouseLabel.Location = new System.Drawing.Point(6, 16);
            this.MouseLabel.Name = "MouseLabel";
            this.MouseLabel.Size = new System.Drawing.Size(189, 85);
            this.MouseLabel.TabIndex = 2;
            this.MouseLabel.Text = "--";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 686);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MouseModeButton);
            this.Controls.Add(this.JoystickModeButton);
            this.Controls.Add(this.PaddleModeButton);
            this.Controls.Add(this.Joystick);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "LEAP Motion Virtual Input Device";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.Joystick.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LeapLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Up;
        private System.Windows.Forms.Label Down;
        private System.Windows.Forms.Label Left;
        private System.Windows.Forms.Label Right;
        private System.Windows.Forms.Label Fire;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel PortName;
        private System.Windows.Forms.ToolStripStatusLabel SerialLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox Joystick;
        private System.Windows.Forms.Button PaddleModeButton;
        private System.Windows.Forms.Button JoystickModeButton;
        private System.Windows.Forms.Button MouseModeButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label PaddleLabel;
        private System.Windows.Forms.Label MouseLabel;
    }
}

