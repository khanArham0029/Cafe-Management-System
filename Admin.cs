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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        String user = "";

        public string ID
        {
            get { return user.ToString(); }
        }
        public Admin(string username)
        {
            InitializeComponent();
            label2.Text = username;
            user = username;
            userControl31.ID = ID;
            userControl41.ID = ID;     
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            userControl11.Visible = true;
            userControl11.BringToFront();

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            userControl11.Visible=false;
            userControl21.Visible=false;
            userControl31.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = false;
            userControl61.Visible = false;
            userControl72.Visible = false;





            button1.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControl21.Visible = true;
            userControl21.BringToFront();

        }

        private void userControl31_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            userControl31.Visible = true;
            userControl31.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControl41.Visible = true;
            userControl41.BringToFront();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            userControl51.Visible = true;
            userControl51.BringToFront();

        }

        private void REPORTS_Click(object sender, EventArgs e)
        {
            userControl61.Visible = true;
            userControl61.BringToFront();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            userControl72.Visible = true;
            userControl72.BringToFront();
        }
    }
}
