using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace TimeTable2
{
    public partial class TeacherDetails : Form
    {

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\VINI\\Desktop\\ProjectTT\\TimeTable.mdb");
        OleDbCommand cmd;
        OleDbDataAdapter adapt;
        String tp = "";
        public TeacherDetails()
        {
            InitializeComponent();
        }

        
        private void TeacherDetails_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            DisplayData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt1.Text != "" )
            {
                cmd = new OleDbCommand("insert into Teacher values(@tname)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@tname", txt1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Inserted Successfully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new OleDbDataAdapter("select * from Teacher", con);
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                
                dataGridView1.DataSource = dt;
                
            }
            con.Close();
        }
        //Clear Data
        private void ClearData()
        {
            txt1.Text = "";
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tp = txt1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt1.Text != "" )
            {
                
                cmd = new OleDbCommand("update Teacher set tname=@name where tname='"+ tp +"'", con);
                con.Open();
                
                cmd.Parameters.AddWithValue("@name", txt1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt1.Text != "")
            {
                cmd = new OleDbCommand("delete from Teacher where tname=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", txt1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }
    }
}
