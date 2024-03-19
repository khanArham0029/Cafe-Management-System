using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFP.Mang
{
    public partial class mControl5 : UserControl
    {
        function fn = new function();
        String query;

        public mControl5()
        {
            InitializeComponent();
        }

        private void mControl5_Load(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                query = "select * from stock where eDate >= getdate()";
                DataSet ds = fn.getData(query);
                dataGridView1.DataSource = ds.Tables[0];
                label3.Text = "Valid STOCK";
                label3.ForeColor = Color.Black;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                query = "select * from stock where eDate <= getdate()";
                DataSet ds = fn.getData(query);
                dataGridView1.DataSource = ds.Tables[0];
                label3.Text = "Expired STOCK";
                label3.ForeColor = Color.Red;

            }
            else if (comboBox1.SelectedIndex == 2)
            {
                query = "select * from stock";
                DataSet ds = fn.getData(query);
                dataGridView1.DataSource = ds.Tables[0];
                label3.Text = "Here is your entire STOCK";
                label3.ForeColor = Color.Blue;


            }



        }
    }
}
