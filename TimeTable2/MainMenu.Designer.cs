namespace TimeTable2
{
    partial class MainMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.teacherDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.practicalDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignPracticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teacherDetailsToolStripMenuItem,
            this.subjectDetailsToolStripMenuItem,
            this.practicalDetailsToolStripMenuItem,
            this.assignSubjectToolStripMenuItem,
            this.assignPracticalToolStripMenuItem,
            this.timeTableToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1230, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // teacherDetailsToolStripMenuItem
            // 
            this.teacherDetailsToolStripMenuItem.Name = "teacherDetailsToolStripMenuItem";
            this.teacherDetailsToolStripMenuItem.Size = new System.Drawing.Size(144, 29);
            this.teacherDetailsToolStripMenuItem.Text = "Teacher Details";
            this.teacherDetailsToolStripMenuItem.Click += new System.EventHandler(this.teacherDetailsToolStripMenuItem_Click);
            // 
            // subjectDetailsToolStripMenuItem
            // 
            this.subjectDetailsToolStripMenuItem.Name = "subjectDetailsToolStripMenuItem";
            this.subjectDetailsToolStripMenuItem.Size = new System.Drawing.Size(144, 29);
            this.subjectDetailsToolStripMenuItem.Text = "Subject Details";
            this.subjectDetailsToolStripMenuItem.Click += new System.EventHandler(this.subjectDetailsToolStripMenuItem_Click);
            // 
            // practicalDetailsToolStripMenuItem
            // 
            this.practicalDetailsToolStripMenuItem.Name = "practicalDetailsToolStripMenuItem";
            this.practicalDetailsToolStripMenuItem.Size = new System.Drawing.Size(150, 29);
            this.practicalDetailsToolStripMenuItem.Text = "Practical Details";
            this.practicalDetailsToolStripMenuItem.Click += new System.EventHandler(this.practicalDetailsToolStripMenuItem_Click);
            // 
            // assignSubjectToolStripMenuItem
            // 
            this.assignSubjectToolStripMenuItem.Name = "assignSubjectToolStripMenuItem";
            this.assignSubjectToolStripMenuItem.Size = new System.Drawing.Size(144, 29);
            this.assignSubjectToolStripMenuItem.Text = "Assign Subject";
            this.assignSubjectToolStripMenuItem.Click += new System.EventHandler(this.assignSubjectToolStripMenuItem_Click);
            // 
            // assignPracticalToolStripMenuItem
            // 
            this.assignPracticalToolStripMenuItem.Name = "assignPracticalToolStripMenuItem";
            this.assignPracticalToolStripMenuItem.Size = new System.Drawing.Size(150, 29);
            this.assignPracticalToolStripMenuItem.Text = "Assign Practical";
            this.assignPracticalToolStripMenuItem.Click += new System.EventHandler(this.assignPracticalToolStripMenuItem_Click);
            // 
            // timeTableToolStripMenuItem
            // 
            this.timeTableToolStripMenuItem.Name = "timeTableToolStripMenuItem";
            this.timeTableToolStripMenuItem.Size = new System.Drawing.Size(106, 29);
            this.timeTableToolStripMenuItem.Text = "TimeTable";
            this.timeTableToolStripMenuItem.Click += new System.EventHandler(this.timeTableToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TimeTable2.Properties.Resources.somaiya;
            this.pictureBox1.Location = new System.Drawing.Point(37, 129);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(953, 265);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(55, 29);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1230, 598);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem teacherDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem practicalDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignSubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignPracticalToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem timeTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}