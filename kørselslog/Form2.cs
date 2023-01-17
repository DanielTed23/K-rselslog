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
    public partial class Form2 : Form
    {

        SqlConnection sqlconn = new SqlConnection(@"Server=tcp:danielserver23.database.windows.net,1433;Initial Catalog=daniel;Persist Security Info=False;User ID=daniel;Password=Keu37tbu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
      
        SqlDataAdapter adpt;
        DataTable dt;

        public Form2()
        {
            InitializeComponent();
            this.Text = "Bruger menu";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           DialogResult iExit;

            try
            {
                iExit = MessageBox.Show("Vil du gå tilbage til hovedmenuen?", "TestDrive", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iExit == DialogResult.Yes)
                {
                    this.Close();   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            showdata();
        }

       

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void showdata()
        {
            adpt = new SqlDataAdapter("Select * from [User]", sqlconn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView3.DataSource = dt;


        }
    }
}
