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
    public partial class UserControl3 : UserControl
    {
        function fn = new function();
        String query;
        String currentUser = "";

        public UserControl3()
        {
            InitializeComponent();
        }

        public String ID
        {
            set { currentUser = value; }
        }

      

        private void UserControl3_Load(object sender, EventArgs e)
        {
            query = "select * from users";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username like '"+textBox1.Text+"%'";
            DataSet ds = fn.getData(query);
            dataGridView1 .DataSource = ds.Tables[0];
        }
        String userName;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                userName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(currentUser != userName)
            {
                query = "delete from users where username = '"+userName+"'";
                fn.setData(query, "User record deleted");
                UserControl3_Load (this, null);
            }

            else
            {

                MessageBox.Show("cant delete your own \n your own profile","oops",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserControl3_Load(this, null);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
