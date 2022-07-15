using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eternals
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f3 = new Form3();
            Form f4 = new Form4();
            if (radioButton1.Checked ==true)
            {
                f3.Show();
                this.Hide();
            }
            if (radioButton2.Checked == true)
            {
                f4.Show();
                this.Hide();
            }


        }
    }
}
