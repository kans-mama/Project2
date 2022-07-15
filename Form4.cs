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
    public partial class Form4 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;

        public Form4()
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
            DB_Connect();
            string blood_grp = textBox1.Text;
            string city = textBox2.Text;
            comm = new OracleCommand();
            comm.CommandText = "select name from blood_bank where address='"+textBox2.Text+"' and blood_type='"+textBox1.Text+"'";
            comm.CommandType = CommandType.Text;
            ds = new DataSet(); 
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "blood_bank");
            dt = ds.Tables["blood_bank"]; 
            int t = dt.Rows.Count;

            MessageBox.Show(t.ToString());

            comboBox1.DataSource = dt.DefaultView;
            comboBox1.DisplayMember = "name";
            
            conn.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();

        }
    }
}
