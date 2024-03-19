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

    public partial class UserControl4 : UserControl
    {

        function fn = new function();
        string query;

        public UserControl4()
        {
            InitializeComponent();
        }

        public string ID
        {
            set { label2.Text = value; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

     

        private void UserControl4_Load(object sender, EventArgs e)
        {
         





        }

       

        private void UserControl4_Enter(object sender, EventArgs e)
        {
            query = "select * from users where username = '" + label2.Text + "'";
            DataSet ds = fn.getData(query);
            comboBox1.Text = ds.Tables[0].Rows[0][1].ToString();
            textBox2.Text = ds.Tables[0].Rows[0][2].ToString();
            textBox3.Text = ds.Tables[0].Rows[0][3].ToString();
            textBox4.Text = ds.Tables[0].Rows[0][4].ToString();
            textBox5.Text = ds.Tables[0].Rows[0][5].ToString();
            textBox6.Text = ds.Tables[0].Rows[0][7].ToString();
             
        }
        private void button2_Click(object sender, EventArgs e)
        {
            UserControl4_Enter(this, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String role = comboBox1.Text;
            String name = textBox2.Text;
            String dob = textBox3.Text;
            Int64 mobile = Int64.Parse(textBox4.Text);
            String email = textBox5.Text;
            String username = label2.Text;
            String pass = textBox6.Text;

            query = "update users set userRole ='"+role+"',name='"+name+"',dob='"+dob+"',mobile ="+mobile+",email='"+email+"',pass='"+pass+"' where username = '"+username+"'";
            fn.setData(query, "profile updated Successful");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
