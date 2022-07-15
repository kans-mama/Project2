using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace eternals
{
    public partial class Form1 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;

        string[] user1= {"a","Ravi","Ashwin","Mohishah","Kavya","Raj","Radhika","Vedant","Shreyansh","AA"};
        string[] password1 = { "b","Kishan", "Gupta", "Khannah", "Shah", "Kundra", "Apte","Chaudhari","Gupta","BB" };

        public Form1()
        {
            InitializeComponent();
        }

        public void DB_Connect()
        {
            String oradb = "Data Source=ictorcl;User ID=it082;Password=student";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        


        private void button1_Click(object sender, EventArgs e)
        {
            
            int j=0,i;
            for (i = 0; i < 10; i++)
            {
                if (username.Text == user1[i] && password.Text == password1[i])
                {
                    MessageBox.Show("AUTHENTICATED");
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                    break;
                    
                }
               
            }
            if (i == 10)
            {
                MessageBox.Show("Invalid Credentials");
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from donor_table";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "donor_table");
            dt = ds.Tables["donor_table"];
            int t = dt.Rows.Count;
            MessageBox.Show(t.ToString());
            dr = dt.Rows[i];
            textBox1.Text = dr["name"].ToString();
            conn.Close();
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
