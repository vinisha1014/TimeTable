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
    public partial class PracticalAssign : Form
    {
        public PracticalAssign()
        {
            InitializeComponent();
        }

        private void PracticalAssign_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'timeTableDataSet3.PracAssign' table. You can move, or remove it, as needed.
            this.pracAssignTableAdapter.Fill(this.timeTableDataSet3.PracAssign);

        }
    }
}
