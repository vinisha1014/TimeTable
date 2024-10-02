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
    public partial class SubjectAssign : Form
    {
        public SubjectAssign()
        {
            InitializeComponent();
        }

        private void SubjectAssign_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'timeTableDataSet2.SubjectAssign' table. You can move, or remove it, as needed.
            this.subjectAssignTableAdapter.Fill(this.timeTableDataSet2.SubjectAssign);

        }
    }
}
