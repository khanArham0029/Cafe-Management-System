using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// add user part
namespace DBFP
{
    public partial class UserControl2 : UserControl
    {
        function fn = new function();
        String query;

        public UserControl2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String role = comboBox1.Text;
            String name = textBox1.Text;
            String dob = dateTimePicker1.Text;
            Int64 mobile = Int64.Parse(textBox2.Text);
            String email = textBox4.Text;
            String username = textBox5.Text;
            String pass = textBox6.Text;

            try
            {
                query = "insert into users (userRole,name,dob,mobile,email,username,pass) values('"+role+"','"+name+ "','"+dob+"',"+mobile+",'"+email+ "','"+username+"','"+pass+"')";
                fn.setData(query, "signed up");
            }
            catch (Exception)
            {
                MessageBox.Show("Username already exist.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        public void clearAll()
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            dateTimePicker1.ResetText();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username = '"+textBox5.Text+"'";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count==0) 
            {
                pictureBox1.ImageLocation = @"C:\Users\ACER\Desktop\cafe MS\Pharmacy Management System in C#\yes.png";
            
            }
            else
            {
                pictureBox1.ImageLocation = @"C:\Users\ACER\Desktop\cafe MS\Pharmacy Management System in C#\no.png";

            }

        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
