using DBFP.Mang;
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
    public partial class Manager : Form
    {
        public Manager()
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
            mControl11.Visible = true;
            mControl11.BringToFront();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            mControl11.Visible= false;
            mControl21.Visible = false;
            mControl41.Visible = false;

            mControl31.Visible = false;

            mControl51.Visible = false;

            mControl61.Visible = false;
            mControl71.Visible = false;


            button1.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mControl21.Visible = true;
            mControl21.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mControl31.Visible = true;
            mControl31.BringToFront();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            mControl41.Visible = true;
            mControl41.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mControl51.Visible = true;
            mControl51.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mControl61.Visible = true;
            mControl61.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mControl71.Visible = true;
            mControl71.BringToFront();

        }
    }
}
