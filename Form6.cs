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
    public partial class Form6 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = "1000";
        }

           public void DB_Connect()
        {
            String oradb = "Data Source=ictorcl;User ID=it082;Password=student";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Sumith Maam")
            {
                DB_Connect();
                comm = new OracleCommand();
                //execute discount()in back end

                comm.CommandText = "select * from blood_disc";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "blood_disc");
                dt = ds.Tables["blood_disc"];
                int t = dt.Rows.Count;
                MessageBox.Show(t.ToString());
                dr = dt.Rows[i];
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "blood_disc"; // Database Table name
                conn.Close();

                
            }
            else
            {
                MessageBox.Show("Invalid code!");
            }
            

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand(); 
            comm.CommandText = "select * from blood"; 
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn); 
            da.Fill(ds, "blood");
            dt = ds.Tables["blood"]; 
            int t = dt.Rows.Count;
            MessageBox.Show(t.ToString()); 
            dr = dt.Rows[i];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "blood"; // Database Table name
            conn.Close();
 }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }
        }
 }

