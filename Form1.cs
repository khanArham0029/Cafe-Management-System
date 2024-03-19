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
    public partial class Form1 : Form
    {
        function fn = new function();
        String query;
        DataSet ds;


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            query = "select * from users";
            ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if (textBox1.Text == "root" && textBox2.Text == "root")
                {
                    Admin admin = new Admin();
                    admin.Show();
                    this.Hide();

                }
            }
            else
            {
                query = "select * from users where username = '" + textBox1.Text + "' and pass ='" + textBox2.Text + "'";
                ds = fn.getData(query);

                if (ds.Tables[0].Rows.Count != 0) { 
                String role = ds.Tables[0].Rows[0][1].ToString();
                if (role == "Admin")
                {
                    Admin admin = new Admin(textBox1.Text);
                    admin.Show();
                    this.Hide();

                }
                else if (role == "Manager")
                {
                    Manager manager = new Manager();
                    manager.Show();
                    this.Hide();
                }
                else if (role == "Customer")
                {
                    Customer customer = new Customer();
                    customer.Show();
                    this.Hide();
                }
               
                }
                else
                {
                  MessageBox.Show("wrong username or password", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }








            //if (textBox1.Text == "Admin" && textBox2.Text == "pass")
            //{
            //    Admin am = new Admin();
            //    am.Show();
            //    this.Hide();

            //}
            //else
            //{

            //    MessageBox.Show("wrong username or password", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
