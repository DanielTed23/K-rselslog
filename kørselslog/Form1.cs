using Kørselslog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kørselslog
{
    public partial class Form1 : Form
    {
        // sql connection til database
        SqlConnection sqlconn = new SqlConnection(@"Server=tcp:danielserver23.database.windows.net,1433;Initial Catalog=daniel;Persist Security Info=False;User ID=daniel;Password=Keu37tbu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        // til at sende query 
        SqlCommand sqlcmd = new SqlCommand();

        string sqlQuery;
        SqlDataAdapter Dta = new SqlDataAdapter();
        SqlDataReader sqlRd;
        DataSet DS = new DataSet();


        public Form1()
        {
            InitializeComponent();
            this.Text = "Kørselslog";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult iExit;

            try
            {
                iExit = MessageBox.Show("Sikker på du vil afslutte?", "TestDrive", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iExit == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_form1_OpenForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconn.Open();
                sqlQuery = "INSERT INTO [User] ([Name]) VALUES(" + "'" + textBox3.Text + "'" + ")";

                sqlcmd = new SqlCommand(sqlQuery, sqlconn);
                sqlRd = sqlcmd.ExecuteReader();
                sqlconn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                foreach (Control c in panel3.Controls)
                {
                    if (c is TextBox)
                    {
                        ((TextBox)c).Clear();
                    }

                }
                sqlconn.Close();
            }
            upLoadData();
        }

        private void upLoadData()
        {
            sqlconn.Open();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "SELECT * FROM[User]";

            sqlRd = sqlcmd.ExecuteReader();

            sqlRd.Close();
            sqlconn.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // combo box 
            SqlCommand cmd = new SqlCommand("Select Id, Name from [User]", sqlconn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            da.Fill(table1);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //opretter log
            try
            {
                sqlconn.Open();
                sqlQuery = "INSERT INTO [Log] ([Name], [Nrplade], [KmTal], [Dato]) VALUES(" + "'" + comboBox1.Text + "', " + "'" + textBox1.Text + "', " + "'" + textBox2.Text + "', " + "'" + textBox4.Text + "')";

                sqlcmd = new SqlCommand(sqlQuery, sqlconn);
                sqlRd = sqlcmd.ExecuteReader();
                sqlconn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                sqlconn.Close();
            }
            upLoadData();

            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
            }
        }
    }
}
