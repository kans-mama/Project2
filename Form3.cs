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
    public partial class Form3 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public Form3()
        {
            InitializeComponent();
        }
        public void DB_Connect()
        {
            String oradb = "Data Source=ictorcl;User ID=it082;Password=student";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_Connect();
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            int id = 1019;
            cm.CommandText = "insert into donor_table values('" + id + "', '" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')"; 
            cm.CommandType =CommandType.Text;
            cm.ExecuteNonQuery();
            MessageBox.Show("Inserted!"); 
            conn.Close();

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }
    }
}
