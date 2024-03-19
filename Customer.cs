using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFP
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         uControl1.Visible = true;
            uControl1.BringToFront();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            
            uControl1.Visible=false;
            uControl21.Visible = false;
            uControl31.Visible = false;
            uControl41.Visible = false;

        }

        private void uControl1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            uControl21.Visible = true;
            uControl21.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            uControl31.Visible = true;
            uControl31.BringToFront();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            uControl41.Visible = true;
            uControl41.BringToFront();
        }
    }
}
