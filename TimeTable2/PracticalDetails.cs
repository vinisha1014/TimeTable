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
    public partial class PracticalDetails : Form
    {
        public PracticalDetails()
        {
            InitializeComponent();
        }

        private void PracticalDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'timeTableDataSet4.Practical' table. You can move, or remove it, as needed.
            this.practicalTableAdapter.Fill(this.timeTableDataSet4.Practical);

        }
    }
}
