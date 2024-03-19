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
    public partial class UserControl1 : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;

        public UserControl1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
           
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            query = "select count(userRole) from users where userRole = 'Admin'";
            ds = fn.getData(query);
            setLabel(ds, label11);

            query = "select count(userRole) from users where userRole = 'Manager'";
            ds = fn.getData(query);
            setLabel(ds, label16);

            query = "select count(userRole) from users where userRole = 'Customer'";
            ds = fn.getData(query);
            setLabel(ds, label17);
        }

        private void setLabel(DataSet ds, Label lb1)
        {
            if(ds.Tables[0].Rows.Count != 0)
            {
                lb1.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                lb1.Text = "0";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserControl1_Load(this, null);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
