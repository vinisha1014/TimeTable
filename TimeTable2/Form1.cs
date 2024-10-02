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
using System.IO;
namespace TimeTable2
{
    public partial class Form1 : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter da;
        DataTable dt;
        OleDbDataAdapter da1;
        DataTable dt1;
        OleDbDataAdapter da2;
        DataTable dt2;
        OleDbDataAdapter da3;
        DataTable dt3;
        OleDbDataAdapter da4;
        DataTable dt4;


        String std;
        int day;
        int slot;
        String teacher, subject, batch;
        int scred;
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void generateodd(int day)
        {


            //// Check if the number of scheduled lectures for the specified day and standard is less than 6
            da = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and Std='" + std + "'", conn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 6)
            {
                //if already 6 lectures
            }
            else
            {
                //Slot-1
                counter = 0;
            number1:
                //delete previous records if exists any
                deletestd(counter++);
                slot = 1;

                //Select a random subject assignment for the specified standard

                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        // Extract teacher, subject, and credits information
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch =''", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 2)
                        {
                            //pehle se he vo din pe lec hai
                            goto number1;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number1;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }
                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 1 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number1;
                                    }


                                }



                            }





                        }






                    }




                }

                //Slot-2
                counter = 0;
            number2:
                deletestd(counter++);
                slot = 2;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 2)

                        {
                            //pehle se he vo din pe lec hai
                            goto number2;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number2;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 2 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number2;
                                    }


                                }



                            }





                        }






                    }




                }


                //Slot-3
                counter = 0;
            number3:
                deletestd(counter++);
                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 2)

                        {
                            //pehle se he vo din pe lec hai
                            goto number3;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number3;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 3 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number3;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot3


                //Slot-4
                counter = 0;
            number4:
                deletestd(counter++);
                slot = 4;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 2)

                        {
                            //pehle se he vo din pe lec hai
                            goto number4;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number4;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 4 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number4;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot4




                //Slot-5 & 6 for Batch C1,C2,C3
                counter = 0;
            number5:
                deletestd(counter++);

                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 1 Batch






                //Slot-5 & 6 for Batch C1,C2,C3
                counter = 0;
            number5b:
                deletestd(counter++);
                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5b;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5b;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5b;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 2 Batch




                //Slot-5 & 6 for Batch C1,C2,C3
                counter = 0;
            number5c:
                deletestd(counter++);
                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5c;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5c;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5c;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 3 Batch




            }



        }


        public int Check(String std)
        {
            int x = 0;
            int assignedcred = 0;
            int totalcred = 0;
            da = new OleDbDataAdapter("select sum(Credit) from TimeTable where Std='" + std + "' and Batch=''", conn);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                assignedcred = Convert.ToInt32(dt.Rows[0][0].ToString());
            }

            da = new OleDbDataAdapter("select sum(Credit) from SubjectAssign where Std='" + std + "'", conn);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                totalcred = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            if (assignedcred < totalcred)
            {
                //aur credits baaki h
                x = 0;
            }
            else
            {
                //credits khatam , practical p jump karo
                x = 1;
            }

            return x;
        }

        public int checkcredits(String std)
        {
            int x = 0;
            int assignedcred = 0;
            int totalcred = 0;
            da = new OleDbDataAdapter("select sum(Credit) from TimeTable where Std='" + std + "' and Batch=''", conn);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                assignedcred = Convert.ToInt32(dt.Rows[0][0].ToString());
            }

            da = new OleDbDataAdapter("select sum(Credit) from SubjectAssign where Std='" + std + "'", conn);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                totalcred = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            if (assignedcred < totalcred)
            {
                //aur credits baaki h
                x = 0;
            }
            else
            {
                //credits khatam , practical p jump karo
                x = 1;
            }

            return x;
        }



        public void generateoddTY(int day)
        {



            da = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and Std='" + std + "'", conn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 6)
            {

            }
            else
            {






                //Slot-3
                counter = 0;
            number1:
                deletestd(counter++);

                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch =''", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 4)
                        {
                            //pehle se he vo din pe lec hai
                            goto number1;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number1;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }
                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 1 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number1;
                                    }


                                }



                            }





                        }






                    }




                }

                //Slot-4
                counter = 0;
            number2:
                deletestd(counter++);

                slot = 4;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 4)
                        {
                            //pehle se he vo din pe lec hai
                            goto number2;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 4)
                            {
                                //teacher busy hai
                                goto number2;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 2 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number2;
                                    }


                                }



                            }





                        }






                    }




                }


                //Slot-5
                counter = 0;
            number3:
                deletestd(counter++);


                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 4)
                        {
                            //pehle se he vo din pe lec hai
                            goto number3;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number3;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 3 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number3;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot3


                //Slot-6
                counter = 0;
            number4:
                deletestd(counter++);

                slot = 6;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 4)
                        {
                            //pehle se he vo din pe lec hai
                            goto number4;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number4;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 4 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number4;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot4




                //Slot-1 & 2 for Batch C1,C2,C3
                counter = 0;
            number5:
                deletestd(counter++);


                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 1 Batch






                //Slot-5 & 6 for Batch C1,C2,C3
                counter = 0;
            number5b:
                deletestd(counter++);

                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5b;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5b;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5b;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 2 Batch




                //Slot-1&2 for Batch C1,C2,C3
                counter = 0;
            number5c:
                deletestd(counter++);


                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5c;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5c;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5c;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot1 for 3 Batch




            }



        }




        public void generatelast(int day)
        {




            da = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and Std='" + std + "'", conn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 6)
            {

            }
            else
            {
                //Slot-1

                int p = checkcredits(std);
                if (p == 1)
                {
                    goto number5;
                }
                counter = 0;
            number1:
                deletestd(counter++);

                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());



                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch =''", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        //random 3 daala h    
                        if (dt2.Rows.Count > 3)
                        {
                            //pehle se he vo din pe lec hai
                            goto number1;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number1;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }
                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 1 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number1;
                                    }


                                }



                            }





                        }






                    }




                }

                //Slot-2
                p = checkcredits(std);
                if (p == 1)
                {
                    goto number5;
                }

                counter = 0;
            number2:
                deletestd(counter++);


                slot = 2;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        //random 3 daala h    
                        if (dt2.Rows.Count > 3)
                        {
                            //pehle se he vo din pe lec hai
                            goto number2;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number2;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 2 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number2;
                                    }


                                }



                            }





                        }






                    }




                }


                //Slot-3
                p = checkcredits(std);
                if (p == 1)
                {
                    goto number5;
                }

                counter = 0;
            number3:
                deletestd(counter++);

                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        //random 3 daala h    
                        if (dt2.Rows.Count > 3)
                        { //pehle se he vo din pe lec hai
                            goto number3;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number3;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 3 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number3;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot3


                //Slot-4
                p = checkcredits(std);
                if (p == 1)
                {
                    goto number5;
                }
                counter = 0;
            number4:
                deletestd(counter++);


                slot = 4;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        //random 3 daala h    
                        if (dt2.Rows.Count > 3)
                        {
                            //pehle se he vo din pe lec hai
                            goto number4;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number4;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 4 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number4;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot4




                //Slot-5 & 6 for Batch C1,C2,C3
                counter = 0;
            number5:
                deletestd(counter++);

                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        //random 3 daala h    
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 1 Batch






                //Slot-5 & 6 for Batch C1,C2,C3
                counter = 0;
            number5b:
                deletestd(counter++);


                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        //random 3 daala h    
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5b;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5b;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5b;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 2 Batch




                //Slot-5 & 6 for Batch C1,C2,C3
                counter = 0;
            number5c:
                deletestd(counter++);

                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        //random 3 daala h    
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5c;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5c;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5c;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 3 Batch




            }



        }


        public void generatelastTY(int day)
        {




            da = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and Std='" + std + "'", conn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 6)
            {

            }
            else
            {



                //Slot 0


                int p = checkcredits(std);
                if (p == 1)
                {
                    goto number5;
                }
                counter = 0;
            number0:
                deletestd(counter++);

                slot = 0;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch =''", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 4)
                        {
                            //pehle se he vo din pe lec hai
                            goto number0;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number0;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }
                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 1 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number0;
                                    }


                                }



                            }





                        }






                    }




                }



                //Slot-1

                p = checkcredits(std);
                if (p == 1)
                {
                    goto number5;
                }

                counter = 0;
            number1:
                deletestd(counter++);

                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());



                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch =''", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        //random 3 daala h    
                        if (dt2.Rows.Count > 3)
                        {
                            //pehle se he vo din pe lec hai
                            goto number1;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number1;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }
                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 1 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number1;
                                    }


                                }



                            }





                        }






                    }




                }

                //Slot-2
                p = checkcredits(std);
                if (p == 1)
                {
                    goto number5;
                }

                counter = 0;
            number2:
                deletestd(counter++);


                slot = 2;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        //random 3 daala h    
                        if (dt2.Rows.Count > 3)
                        {
                            //pehle se he vo din pe lec hai
                            goto number2;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number2;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 2 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number2;
                                    }


                                }



                            }





                        }






                    }




                }


                //Slot-3
                p = checkcredits(std);
                if (p == 1)
                {
                    goto number5;
                }

                counter = 0;

            number3:
                deletestd(counter++);

                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        //random 3 daala h    
                        if (dt2.Rows.Count > 3)
                        { //pehle se he vo din pe lec hai
                            goto number3;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number3;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 3 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number3;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot3


                //Slot-4
                p = checkcredits(std);
                if (p == 1)
                {
                    goto number5;
                }
                counter = 0;

            number4:

                deletestd(counter++);


                slot = 4;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        //random 3 daala h    
                        if (dt2.Rows.Count > 3)
                        {
                            //pehle se he vo din pe lec hai
                            goto number4;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number4;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 4 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number4;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot4




                //Slot-5 & 6 for Batch C1,C2,C3
                counter = 0;
            number5:
                deletestd(counter++);

                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        //random 3 daala h    
                        if (dt2.Rows.Count > 3)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 1 & 2 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 1 Batch






                //Slot-5 & 6 for Batch C1,C2,C3
                counter = 0;
            number5b:
                deletestd(counter++);


                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        //random 3 daala h    
                        if (dt2.Rows.Count > 3)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5b;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5b;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 1 & 2 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5b;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 2 Batch




                //Slot-3 & 4 for Batch C1,C2,C3
                counter = 0;
            number5c:
                deletestd(counter++);

                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        //random 3 daala h    
                        if (dt2.Rows.Count > 3)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5c;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5c;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 3 & 4 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5c;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 3 Batch




            }



        }

        public void generateeven(int day)
        {



            da = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and Std='" + std + "'", conn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 6)
            {

            }
            else
            {
                //Slot-3
                counter = 0;
            number1:
                deletestd(counter++);

                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch =''", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 2)

                        {
                            //pehle se he vo din pe lec hai
                            goto number1;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number1;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }
                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 1 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number1;
                                    }


                                }



                            }





                        }






                    }




                }

                //Slot-4
                counter = 0;
            number2:
                deletestd(counter++);
                slot = 4;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 2)

                        {
                            //pehle se he vo din pe lec hai
                            goto number2;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number2;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 2 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number2;
                                    }


                                }



                            }





                        }






                    }




                }


                //Slot-5
                counter = 0;
            number3:
                deletestd(counter++);
                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 2)

                        {
                            //pehle se he vo din pe lec hai
                            goto number3;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number3;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 3 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number3;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5


                //Slot-6
                counter = 0;
            number4:
                deletestd(counter++);

                slot = 6;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 2)

                        {
                            //pehle se he vo din pe lec hai
                            goto number4;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number4;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 4 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number4;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot6




                //Slot-1 & 2 for Batch 2 batches
                counter = 0;
            number5:
                deletestd(counter++);

                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot1 for 1 Batch






                //Slot-1 & 2 for 2 batches Batch 
                counter = 0;
            number5b:
                deletestd(counter++);

                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5b;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5b;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5b;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 2 Batch






            }



        }


        void deletestd(int count)
        {
            if (count >= 40)
            {
                try
                {
                    conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\VINI\\Desktop\\ProjectTT\\TimeTable.mdb");
                    conn.Close();
                    conn.Open();
                    cmd = new OleDbCommand("delete from TimeTable where Std='" + comboBox1.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Deleted!!!!");
                }
                catch { }

                try
                {
                    conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\VINI\\Desktop\\ProjectTT\\TimeTable.mdb");
                    conn.Close();
                    conn.Open();
                    //MessageBox.Show("Connected");
                    std = comboBox1.Text;

                    //timer1.Start();

                    if (std.Equals("Select"))
                    {
                        //MessageBox.Show("Select Std");
                    }

                    if (std.Equals("FY"))

                    {

                        for (int i = 1; i <= 5; i++)
                        {
                            day = i;

                            if (day == 1)
                            {
                                generate15fy(day);
                                //MessageBox.Show(day + "completed");

                            }
                            if (day == 5)
                            {
                                generatelastfy(day);
                                //MessageBox.Show(day + "completed");
                                this.Close();

                            }
                            if (day == 2 || day == 3 || day == 4)
                            {
                                generate234fy(day);
                                //MessageBox.Show(day + "completed");

                            }


                            da = new OleDbDataAdapter("Select * from TimeTable where Std='" + std + "'", conn);
                            dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dt;
                            }
                        }
                        MessageBox.Show("FY Done");
                    }
                    else if (std.Equals("SY"))
                    {

                        //check day 
                        for (int i = 1; i <= 6; i++)
                        {
                            day = i;

                            if (day % 2 == 0 && day != 6)
                            {
                                generateodd(day);
                            }
                            if (day % 2 == 1)
                            {
                                generateeven(day);

                            }

                            //FY K LIYE, KYUKI UNKO LAST DAY NAHE H
                            int p = Check(std);
                            if (p == 1)
                            {
                                break;
                            }



                            if (day == 6)
                            {
                                generatelast(day);
                                this.Close();
                            }

                            da = new OleDbDataAdapter("Select * from TimeTable where Std='" + std + "'", conn);
                            dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dt;
                            }





                        }
                        MessageBox.Show("SY Done");
                    }
                    else if (std.Equals("TY"))
                    {



                        //check day 

                        for (int i = 1; i <= 6; i++)
                        {
                            day = i;

                            if (day == 1 || day == 3)
                            {
                                generateTYday13(day);
                                //MessageBox.Show("Day 1 & 3 Completed");
                            }
                            if (day == 2)
                            {
                                generateTYday2(day);
                                //MessageBox.Show("Day 2 Completed");

                            }
                            if (day == 4)
                            {

                                generateoddTY(day);
                                //MessageBox.Show("Day 4 Completed");
                            }
                            if (day == 5)
                            {
                                generateevenTY(day);
                                //MessageBox.Show("Day 5 Completed");
                            }


                            //FY K LIYE, KYUKI UNKO LAST DAY NAHE H



                            //int p = Check(std);
                            //if (p == 1)
                            //{
                            //    break;
                            //}



                            if (day == 6)
                            {
                                generatelastTY(day);
                                //MessageBox.Show("Day 6 Completed");
                                this.Close();
                            }

                            da = new OleDbDataAdapter("Select * from TimeTable where Std='" + std + "'", conn);
                            dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dt;
                            }





                        }
                        MessageBox.Show("TY Done");


                    }



                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex + "");
                }

            }
        }

        public void generate234fy(int day)
        {



            da = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and Std='" + std + "'", conn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 6)
            {

            }
            else
            {
                //Slot-1

                counter = 0;
            number1:
                deletestd(counter++);

                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch =''", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 8)
                        {
                            //pehle se he vo din pe lec hai
                            goto number1;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number1;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }
                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 1 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number1;
                                    }


                                }



                            }





                        }






                    }




                }

                //Slot-2

                counter = 0;
            number2:
                deletestd(counter++);
                slot = 2;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 8)
                        {
                            //pehle se he vo din pe lec hai
                            goto number2;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number2;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 2 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number2;
                                    }


                                }



                            }





                        }






                    }




                }


                //Slot-3
                counter = 0;
            number3:
                deletestd(counter++);
                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "' and Time=" + slot + "", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number3;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number3;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 3 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number3;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot3


                //Slot-4
                counter = 0;
            number4:
                deletestd(counter++);
                slot = 4;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "' and Time=" + slot + "", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {       //pehle se he vo din pe lec hai
                            goto number4;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number4;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 4 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number4;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot6




                //Slot-1 & 2 for Batch 2 batches
                counter = 0;
            number5:
                deletestd(counter++);
                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "' and Time=" + slot + "", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {          //pehle se he vo din pe lec hai
                            goto number5;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot1 for 1 Batch






                //Slot-1 & 2 for 2 batches Batch 
                counter = 0;
            number5b:
                deletestd(counter++);
                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "' and Time=" + slot + "", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5b;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5b;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5b;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 2 Batch


                //Slot-1 & 2 for 3 batches Batch 
                counter = 0;
            number5c:
                deletestd(counter++);
                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "' and Time=" + slot + "", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {      //pehle se he vo din pe lec hai
                            goto number5c;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5c;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5c;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 3 Batch





            }



        }

        public void generateevenTY(int day)
        {



            da = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and Std='" + std + "'", conn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 6)
            {

            }
            else
            {




                //Slot-1 & 2 for Batch 2 batches

                //check kro same day p pracs ho toh b chalega
                //change labels for slot 1 & 2

                counter = 0;
            number1:
                deletestd(counter++);

                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number1;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number1;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 1 & 2 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number1;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot1 for 1 Batch






                //Slot-1 & 2 for 2 batches Batch 
                counter = 0;
            number1b:
                deletestd(counter++);


                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number1b;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number1b;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 1 & 2 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number1b;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot2 for 2 Batch





                //Slot-3
                counter = 0;
            number3:
                deletestd(counter++);


                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch =''", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number3;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number3;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }
                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 3 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number3;
                                    }


                                }



                            }





                        }






                    }




                }

                //Slot-4
                counter = 0;
            number4:
                deletestd(counter++);


                slot = 4;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number4;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number4;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 4 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number4;
                                    }


                                }



                            }





                        }






                    }




                }





                //Slot-5 & 6 for Batch 2 batches
                counter = 0;
            number5:
                deletestd(counter++);


                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);

                        //jaan bujke count change kia , taaki same day pe same batch ka ho fir b code aage chale
                        if (dt2.Rows.Count > 4)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot1 for 1 Batch






                //Slot-5 & 6 for 2 batches Batch 
                counter = 0;
            number5b:
                deletestd(counter++);


                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "' and Time=" + slot + "", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5b;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5b;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5b;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 2 Batch






            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\VINI\\Desktop\\ProjectTT\\TimeTable.mdb");
                conn.Close();
                conn.Open();
                cmd = new OleDbCommand("delete from TimeTable where Std='" + comboBox1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Deleted!!!!");
            }
            catch { }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\VINI\\Desktop\\ProjectTT\\TimeTable.mdb");
                conn.Close();
                conn.Open();
                //MessageBox.Show("Connected");
                std = comboBox1.Text;

                //timer1.Start();

                if (std.Equals("Select"))
                {
                    //MessageBox.Show("Select Std");
                }

                if (std.Equals("FY"))

                {

                    for (int i = 1; i <= 5; i++)
                    {
                        day = i;

                        if (day == 1)
                        {
                            generate15fy(day);
                            //MessageBox.Show(day + "completed");

                        }
                        if (day == 5)
                        {
                            generatelastfy(day);
                            //MessageBox.Show(day + "completed");
                            day = day + 10;

                        }
                        if (day == 2 || day == 3 || day == 4)
                        {
                            generate234fy(day);
                            //MessageBox.Show(day + "completed");

                        }


                        da = new OleDbDataAdapter("Select * from TimeTable where Std='" + std + "'", conn);
                        dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt;
                        }
                    }
                    MessageBox.Show("FY Done");
                }
                else if (std.Equals("SY"))
                {

                    //check day 
                    for (int i = 1; i <= 6; i++)
                    {
                        day = i;

                        if (day % 2 == 0 && day != 6)
                        {
                            generateodd(day);
                        }
                        if (day % 2 == 1)
                        {
                            generateeven(day);

                        }

                        //FY K LIYE, KYUKI UNKO LAST DAY NAHE H
                        int p = Check(std);
                        if (p == 1)
                        {
                            break;
                        }



                        if (day == 6)
                        {
                            generatelast(day);

                        }

                        da = new OleDbDataAdapter("Select * from TimeTable where Std='" + std + "'", conn);
                        dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt;
                        }





                    }
                    MessageBox.Show("SY Done");
                }
                else if (std.Equals("TY"))
                {



                    //check day 
                    for (int i = 1; i <= 6; i++)
                    {
                        day = i;

                        if (day == 1 || day == 3)
                        {
                            generateTYday13(day);
                            //MessageBox.Show("Day 1 & 3 Completed");
                        }
                        if (day == 2)
                        {
                            generateTYday2(day);
                            //MessageBox.Show("Day 2 Completed");

                        }
                        if (day == 4)
                        {

                            generateoddTY(day);
                            //MessageBox.Show("Day 4 Completed");
                        }
                        if (day == 5)
                        {
                            generateevenTY(day);
                            //MessageBox.Show("Day 5 Completed");
                        }


                        //FY K LIYE, KYUKI UNKO LAST DAY NAHE H



                        //int p = Check(std);
                        //if (p == 1)
                        //{
                        //    break;
                        //}



                        if (day == 6)
                        {
                            generatelastTY(day);
                            //MessageBox.Show("Day 6 Completed");

                        }

                        da = new OleDbDataAdapter("Select * from TimeTable where Std='" + std + "'", conn);
                        dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt;
                        }





                    }
                    MessageBox.Show("TY Done");


                }



            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex + "");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String html = "";
                html = html + "<table border=1 cellspacing=5 cellpadding=5>";
                html = html + "<caption><b>Timetable- " + comboBox1.Text + "</b></caption>";
                html = html + "<tr><th>Day/Time</th><th>9:30-10:30</th><th>10:30-11:30</th><th>11:30-12:30</th><th>1:15-2:15</th><th>2:15-3:15</th><th>3:30-4:30</th><th>4:30-5:30</th></tr>";

                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\VINI\\Desktop\\ProjectTT\\TimeTable.mdb");
                conn.Close();
                conn.Open();

                String myday = "";
                for (int day = 1; day <= 6; day++)
                {
                    html = html + "<tr>";
                    if (day == 1)
                    {
                        myday = "Monday";
                    }

                    if (day == 2)
                    {
                        myday = "Tuesday";
                    }
                    if (day == 3)
                    {
                        myday = "Wednesday";
                    }
                    if (day == 4)
                    {
                        myday = "Thursday";
                    }
                    if (day == 5)
                    {
                        myday = "Friday";
                    }
                    if (day == 6)
                    {
                        myday = "Saturday";
                    }











                    da = new OleDbDataAdapter("Select * from TimeTable where Std='" + comboBox1.Text + "' and Day=" + day + "", conn);
                    dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        html = html + "<th>" + myday + "</th>";

                        for (int slot = 0; slot <= 6; slot++)
                        {
                            da = new OleDbDataAdapter("Select * from TimeTable where Std='" + comboBox1.Text + "' and Day=" + day + " and Time=" + slot + "", conn);
                            dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {

                                //agar vo day pe vo slot h
                                //nikalo count
                                //loop lagao utne baar taaki br tag use kre
                                html = html + "<th>";
                                for (int x = 0; x < dt.Rows.Count; x++)
                                {
                                    html = html + dt.Rows[x][3].ToString() + "-" + dt.Rows[x][4].ToString();
                                    if (dt.Rows[x][5].ToString().Equals(""))
                                    {
                                        //batch nahe toh kch mat kro.
                                    }
                                    else
                                    {
                                        html = html + "(" + dt.Rows[x][5].ToString() + ")<br>";
                                    }

                                }
                                html = html + "</th>";


                            }
                            else
                            {
                                //agar slot nahe h toh blank
                                html = html + "<th>-</th>";
                            }



                        }




                    }



                    html = html + "</tr>";
                }








                html = html + "</table>";
                File.WriteAllText(comboBox1.Text + ".html", html);
                //MessageBox.Show("Time Table Saved!!");
            }
            catch
            {

            }
        }

        public void generate15fy(int day)
        {



            da = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and Std='" + std + "'", conn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 6)
            {

            }
            else
            {
                //Slot-1
                counter = 0;
            number1:
                deletestd(counter++);
                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch =''", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number1;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number1;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }
                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 1 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number1;
                                    }


                                }



                            }





                        }






                    }




                }

                //Slot-2
                counter = 0;
            number2:
                deletestd(counter++);
                slot = 2;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number2;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number2;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 2 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number2;
                                    }


                                }



                            }





                        }






                    }




                }


                //Slot-3,4 for 3 batches


                counter = 0;
            number3:
                deletestd(counter++);
                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number3;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number3;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 3 & 4 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number3;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot3 for 1 Batch






                //Slot-3 for 2nd batches Batch 
                counter = 0;
            number3b:
                deletestd(counter++);
                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number3b;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number3b;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 3 & 4 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number3b;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot3 for 2 Batch





                //Slot-3 for 2nd batches Batch 
                counter = 0;
            number3c:
                deletestd(counter++);
                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number3c;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number3c;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 3 & 4 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number3c;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot3 for 3 Batch



                //slot--5 for 3 batches



                //Slot-3,4 for 3 batches


                counter = 0;
            number5:
                deletestd(counter++);
                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "' and Time=" + slot + "", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot3 for 1 Batch






                //Slot-3 for 2nd batches Batch 
                counter = 0;
            number5b:
                deletestd(counter++);
                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "' and Time=" + slot + "", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5b;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5b;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5b;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot3 for 2 Batch





                //Slot-3 for 2nd batches Batch 
                counter = 0;
            number5c:
                deletestd(counter++);
                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "' and Time=" + slot + "", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5c;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5c;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5c;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 3 Batch






            }



        }



        public void generatelastfy(int day)
        {

            da = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and Std='" + std + "'", conn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 6)
            {

            }
            else
            {
                //Slot-1
                counter = 0;
            number1:
                deletestd(counter++);
                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch =''", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number1;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number1;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }
                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 1 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number1;
                                    }


                                }



                            }





                        }






                    }




                }

                //Slot-2
                counter = 0;
            number2:
                deletestd(counter++);
                slot = 2;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 8)
                        {
                            //pehle se he vo din pe lec hai
                            goto number2;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number2;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 2 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number2;
                                    }


                                }



                            }





                        }






                    }




                }


                //Slot-3,4 for 3 batches


                counter = 0;
            number3:
                deletestd(counter++);
                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "' and Time=" + slot + "", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number3;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number3;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 3 & 4 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number3;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot3 for 1 Batch






                //Slot-3 for 2nd batches Batch 
                counter = 0;
            number3b:
                deletestd(counter++);

                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "' and Time=" + slot + "", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number3b;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number3b;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 3 & 4 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number3b;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot3 for 2 Batch





                //Slot-3 for 2nd batches Batch 
                counter = 0;
            number3c:
                deletestd(counter++);

                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "' and Time=" + slot + "", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {       //pehle se he vo din pe lec hai
                            goto number3c;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number3c;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 3 & 4 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number3c;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot3 for 3 Batch



                //slot--5 for 3 batches



                //Slot-3,4 for 3 batches


                counter = 0;
            number5:
                deletestd(counter++);

                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "' and Time=" + slot + "", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot3 for 1 Batch






                //Slot-3 for 2nd batches Batch 
                counter = 0;
            number5b:
                deletestd(counter++);

                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "' and Time=" + slot + "", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5b;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5b;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5b;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot3 for 2 Batch





                //Slot-3 for 2nd batches Batch 
                counter = 0;
            number5c:
                deletestd(counter++);

                slot = 5;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "' and Time=" + slot + "", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5c;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5c;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5c;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 3 Batch






            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)

        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\VINI\\Desktop\\ProjectTT\\TimeTable.mdb");
            conn.Close();
            conn.Open();

            da = new OleDbDataAdapter("select * from TimeTable where Std='" + comboBox1.Text + "' order by Day", conn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;

            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(sender, e);
        }

        public void generateTYday13(int day)
        {



            da = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and Std='" + std + "'", conn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 6)
            {

            }
            else
            {
                //Slot-3
                counter = 0;
            number1:
                deletestd(counter++);
                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch =''", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number1;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number1;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }
                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 1 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number1;
                                    }


                                }



                            }





                        }






                    }




                }

                //Slot-4
                counter = 0;
            number2:
                deletestd(counter++);

                slot = 4;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number2;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number2;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 2 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number2;
                                    }


                                }



                            }





                        }






                    }




                }


                //Slot-5


                //C1
                slot = 5;
                cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'Project','','1st',1)", conn);
                cmd.ExecuteNonQuery();
                slot = slot + 1;
                cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'Project','','1st',1)", conn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Project Added");

                //C2
                slot = 5;
                cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'Project','','2nd',1)", conn);
                cmd.ExecuteNonQuery();
                slot = slot + 1;
                cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'Project','','2nd',1)", conn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Project Added");

                //C3
                slot = 5;
                cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'Project','','3rd',1)", conn);
                cmd.ExecuteNonQuery();
                slot = slot + 1;
                cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'Project','','3rd',1)", conn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Project Added");



                //end of slot5







                //Slot-1 & 2 for Batch 2 batches
                counter = 0;
            number5:
                deletestd(counter++);

                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot1 for 1 Batch






                //Slot-1 & 2 for 2 batches Batch 
                counter = 0;
            number5b:
                deletestd(counter++);


                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5b;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5b;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5b;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 2 Batch






            }



        }


        public void generateTYday2(int day)
        {



            da = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and Std='" + std + "'", conn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 6)
            {

            }
            else
            {
                //Slot-3
                counter = 0;
            number1:
                deletestd(counter++);

                slot = 3;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch =''", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number1;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number1;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }
                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 1 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number1;
                                    }


                                }



                            }





                        }






                    }




                }

                //Slot-4
                counter = 0;
            number2:
                deletestd(counter++);


                slot = 4;
                da = new OleDbDataAdapter("SELECT top 1 Id from SubjectAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from SubjectAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][3].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][4].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and  SuborPrac='" + subject + "' and Batch ='' ", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number2;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number2;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','',1)", conn);
                                        cmd.ExecuteNonQuery();
                                        //MessageBox.Show("Slot 2 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number2;
                                    }


                                }



                            }





                        }






                    }




                }


                //Slot-5


                //C1
                slot = 5;
                cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'Project','','1st',1)", conn);
                cmd.ExecuteNonQuery();
                slot = slot + 1;
                cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'Project','','1st',1)", conn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Project Added");

                //C2
                slot = 5;
                cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'Project','','2nd',1)", conn);
                cmd.ExecuteNonQuery();
                slot = slot + 1;
                cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'Project','','2nd',1)", conn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Project Added");

                //C3
                slot = 5;
                cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'Project','','3rd',1)", conn);
                cmd.ExecuteNonQuery();
                slot = slot + 1;
                cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'Project','','3rd',1)", conn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Project Added");



                //end of slot5







                //Slot-1 & 2 for Batch 2 batches
                counter = 0;
            number5:
                deletestd(counter++);

                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot1 for 1 Batch






                //Slot-1 & 2 for 2 batches Batch 
                counter = 0;
            number5b:
                deletestd(counter++);

                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5b;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5b;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5b;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 2 Batch








                //Slot-1 & 2 for 3 batches Batch 
                counter = 0;
            number5c:
                deletestd(counter++);

                slot = 1;
                da = new OleDbDataAdapter("SELECT top 1 Id from PracAssign where Std='" + std + "' ORDER BY rnd(Id)", conn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    da1 = new OleDbDataAdapter("SELECT * from PracAssign where Std='" + std + "' and Id=" + id + "", conn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        teacher = dt1.Rows[0][4].ToString();
                        subject = dt1.Rows[0][2].ToString();
                        batch = dt1.Rows[0][3].ToString();
                        scred = Convert.ToInt32(dt1.Rows[0][5].ToString());
                        //matlab theory lec hai
                        //check vo std ka, vo din pe,vo subject ka lec hai
                        da2 = new OleDbDataAdapter("select * from TimeTable where Std='" + std + "' and Day=" + day + " and Batch ='" + batch + "'", conn);
                        dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            //pehle se he vo din pe lec hai
                            goto number5c;

                        }
                        else
                        {
                            //lec nahe h toh 
                            //check kro teacher available h

                            da3 = new OleDbDataAdapter("select * from TimeTable where Day=" + day + " and  Time=" + slot + " and Teacher='" + teacher + "'", conn);
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                //teacher busy hai
                                goto number5c;

                            }
                            else
                            {
                                //teacher free hai.
                                //abe check kro credits

                                da4 = new OleDbDataAdapter("select sum(Credit) from TimeTable where SuborPrac='" + subject + "' and Std='" + std + "' and Batch='" + batch + "'", conn);
                                dt4 = new DataTable();
                                da4.Fill(dt4);
                                if (dt4.Rows.Count > 0)
                                {
                                    String mycred;
                                    if (dt4.Rows[0][0].ToString().Equals(""))
                                    {
                                        mycred = "0";
                                    }
                                    else
                                    {
                                        mycred = dt4.Rows[0][0].ToString();
                                    }

                                    int usedcred = Convert.ToInt32(mycred);
                                    if (usedcred < scred)
                                    {
                                        //toh cred available h, insert kro
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();

                                        slot = slot + 1;
                                        cmd = new OleDbCommand("insert into TimeTable values('" + std + "'," + day + "," + slot + ",'" + subject + "','" + teacher + "','" + batch + "',1)", conn);
                                        cmd.ExecuteNonQuery();


                                        //MessageBox.Show("Slot 5 & 6 Added");

                                    }
                                    else
                                    {
                                        //creds not available

                                        goto number5c;
                                    }


                                }



                            }





                        }






                    }




                }

                //end of slot5 for 3 Batch




            }



        }



    }
}
