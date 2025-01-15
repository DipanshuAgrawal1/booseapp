namespace main
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ProgramWindow = new TextBox();
            OutputWindow = new PictureBox();
            ErrorWindow = new RichTextBox();
            panel1 = new Panel();
            PlayBtn = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            ResetBtn = new Panel();
            SoundBtn = new Panel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveImageToolStripMenuItem = new ToolStripMenuItem();
            loadImageToolStripMenuItem = new ToolStripMenuItem();
            canvasToolStripMenuItem = new ToolStripMenuItem();
            mouseEventToolStripMenuItem = new ToolStripMenuItem();
            penToolStripMenuItem = new ToolStripMenuItem();
            circleToolStripMenuItem = new ToolStripMenuItem();
            eraserToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)OutputWindow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ProgramWindow
            // 
            ProgramWindow.BackColor = Color.FromArgb(239, 216, 183);
            ProgramWindow.BorderStyle = BorderStyle.None;
            ProgramWindow.Location = new Point(126, 461);
            ProgramWindow.Margin = new Padding(2);
            ProgramWindow.Multiline = true;
            ProgramWindow.Name = "ProgramWindow";
            ProgramWindow.Size = new Size(400, 340);
            ProgramWindow.TabIndex = 1;
            // 
            // OutputWindow
            // 
            OutputWindow.BackColor = Color.FromArgb(239, 216, 183);
            OutputWindow.Location = new Point(698, 461);
            OutputWindow.Margin = new Padding(2);
            OutputWindow.Name = "OutputWindow";
            OutputWindow.Size = new Size(398, 316);
            OutputWindow.TabIndex = 2;
            OutputWindow.TabStop = false;
            OutputWindow.Paint += OutputWindow_Paint;
            // 
            // ErrorWindow
            // 
            ErrorWindow.BackColor = Color.FromArgb(239, 216, 183);
            ErrorWindow.BorderStyle = BorderStyle.None;
            ErrorWindow.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ErrorWindow.ForeColor = Color.Red;
            ErrorWindow.Location = new Point(1271, 461);
            ErrorWindow.Margin = new Padding(2);
            ErrorWindow.Name = "ErrorWindow";
            ErrorWindow.Size = new Size(412, 340);
            ErrorWindow.TabIndex = 3;
            ErrorWindow.Text = "";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = Properties.Resources.Drawer_Pro_12_23_2024;
            panel1.Location = new Point(356, -29);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1048, 242);
            panel1.TabIndex = 4;
            // 
            // PlayBtn
            // 
            PlayBtn.BackColor = Color.Transparent;
            PlayBtn.BackgroundImage = Properties.Resources._12_23_2024;
            PlayBtn.Location = new Point(1409, 70);
            PlayBtn.Margin = new Padding(2);
            PlayBtn.Name = "PlayBtn";
            PlayBtn.Size = new Size(78, 90);
            PlayBtn.TabIndex = 5;
            PlayBtn.Click += PlayBtn_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(140, 72, 37);
            panel3.BackgroundImage = Properties.Resources.err1;
            panel3.Location = new Point(1342, 340);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(275, 62);
            panel3.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(140, 72, 37);
            panel4.BackgroundImage = Properties.Resources.input270;
            panel4.Location = new Point(188, 342);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(268, 62);
            panel4.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(140, 72, 37);
            panel5.BackgroundImage = Properties.Resources.out1;
            panel5.Location = new Point(755, 344);
            panel5.Margin = new Padding(2);
            panel5.Name = "panel5";
            panel5.Size = new Size(269, 55);
            panel5.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.back1;
            pictureBox1.Location = new Point(45, 302);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(550, 552);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = Properties.Resources.back1;
            pictureBox2.Location = new Point(621, 302);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(550, 552);
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImage = Properties.Resources.back1;
            pictureBox3.Location = new Point(1199, 302);
            pictureBox3.Margin = new Padding(2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(550, 552);
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            // 
            // ResetBtn
            // 
            ResetBtn.BackColor = Color.Transparent;
            ResetBtn.BackgroundImage = Properties.Resources.reset;
            ResetBtn.Location = new Point(1512, 70);
            ResetBtn.Margin = new Padding(2);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(96, 90);
            ResetBtn.TabIndex = 6;
            ResetBtn.Click += ResetBtn_Click;
            // 
            // SoundBtn
            // 
            SoundBtn.BackColor = Color.Transparent;
            SoundBtn.BackgroundImage = Properties.Resources.sound;
            SoundBtn.Location = new Point(1636, 70);
            SoundBtn.Margin = new Padding(2);
            SoundBtn.Name = "SoundBtn";
            SoundBtn.Size = new Size(96, 90);
            SoundBtn.TabIndex = 7;
            SoundBtn.Click += SoundBtn_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, canvasToolStripMenuItem, mouseEventToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 2, 0, 2);
            menuStrip1.Size = new Size(1778, 33);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveImageToolStripMenuItem, loadImageToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveImageToolStripMenuItem
            // 
            saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            saveImageToolStripMenuItem.Size = new Size(208, 34);
            saveImageToolStripMenuItem.Text = "Save Image";
            saveImageToolStripMenuItem.Click += saveImageToolStripMenuItem_Click;
            // 
            // loadImageToolStripMenuItem
            // 
            loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            loadImageToolStripMenuItem.Size = new Size(208, 34);
            loadImageToolStripMenuItem.Text = "Load Image";
            loadImageToolStripMenuItem.Click += loadImageToolStripMenuItem_Click;
            // 
            // canvasToolStripMenuItem
            // 
            canvasToolStripMenuItem.Name = "canvasToolStripMenuItem";
            canvasToolStripMenuItem.Size = new Size(84, 29);
            canvasToolStripMenuItem.Text = "Canvas";
            // 
            // mouseEventToolStripMenuItem
            // 
            mouseEventToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { penToolStripMenuItem, circleToolStripMenuItem, eraserToolStripMenuItem });
            mouseEventToolStripMenuItem.Name = "mouseEventToolStripMenuItem";
            mouseEventToolStripMenuItem.Size = new Size(130, 29);
            mouseEventToolStripMenuItem.Text = "Mouse Event";
            // 
            // penToolStripMenuItem
            // 
            penToolStripMenuItem.Name = "penToolStripMenuItem";
            penToolStripMenuItem.Size = new Size(270, 34);
            penToolStripMenuItem.Text = "Pen";
            penToolStripMenuItem.Click += penToolStripMenuItem_Click;
            // 
            // circleToolStripMenuItem
            // 
            circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            circleToolStripMenuItem.Size = new Size(270, 34);
            circleToolStripMenuItem.Text = "Circle";
            circleToolStripMenuItem.Click += circleToolStripMenuItem_Click;
            // 
            // eraserToolStripMenuItem
            // 
            eraserToolStripMenuItem.Name = "eraserToolStripMenuItem";
            eraserToolStripMenuItem.Size = new Size(270, 34);
            eraserToolStripMenuItem.Text = "Eraser";
            eraserToolStripMenuItem.Click += eraserToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 128);
            BackgroundImage = Properties.Resources.village_1;
            ClientSize = new Size(1778, 900);
            Controls.Add(SoundBtn);
            Controls.Add(ResetBtn);
            Controls.Add(OutputWindow);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(PlayBtn);
            Controls.Add(ErrorWindow);
            Controls.Add(ProgramWindow);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(menuStrip1);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)OutputWindow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox ProgramWindow;
        private PictureBox OutputWindow;
        private RichTextBox ErrorWindow;
        private Panel panel1;
        private Panel PlayBtn;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Panel ResetBtn;
        private Panel SoundBtn;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem canvasToolStripMenuItem;
        private ToolStripMenuItem saveImageToolStripMenuItem;
        private ToolStripMenuItem loadImageToolStripMenuItem;
        private ToolStripMenuItem mouseEventToolStripMenuItem;
        private ToolStripMenuItem penToolStripMenuItem;
        private ToolStripMenuItem circleToolStripMenuItem;
        private ToolStripMenuItem eraserToolStripMenuItem;
    }
}
