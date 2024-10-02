using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTable2
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void teacherDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherDetails td = new TeacherDetails();
            td.Show();

        }

        private void subjectDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubjectDetails td = new SubjectDetails();
            td.Show();
        }

        private void practicalDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PracticalDetails td = new PracticalDetails();
            td.Show();
        }

        private void assignSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubjectAssign td = new SubjectAssign();
            td.Show();
        }

        private void assignPracticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PracticalAssign td = new PracticalAssign();
            td.Show();
        }

        private void timeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 td = new Form1();
            td.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }
    }
}

