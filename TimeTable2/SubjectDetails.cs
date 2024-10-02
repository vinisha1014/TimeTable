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
    public partial class SubjectDetails : Form
    {
        public SubjectDetails()
        {
            InitializeComponent();
        }

        private void SubjectDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'timeTableDataSet1.Subjects' table. You can move, or remove it, as needed.
            this.subjectsTableAdapter.Fill(this.timeTableDataSet1.Subjects);

        }
    }
}
