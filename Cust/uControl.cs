using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFP.Cust
{
    public partial class uControl : UserControl
    {
        function fn = new function();
        String query;
        String query1;
        String query2;
        String query3;
        String query4;
        String query5;

        public uControl()
        {
            InitializeComponent();
        }

        private void uControl_Load(object sender, EventArgs e)
        {   
            //Juices
            query = "SELECT mname AS 'Item Name', perUnit AS 'Price' FROM stock WHERE mnumber = 'Juices'";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
            //Biscuits
            query1 = "SELECT mname AS 'Item Name', perUnit AS 'Price' FROM stock WHERE mnumber = 'Biscuits'";
            DataSet ds1 = fn.getData(query1);
            dataGridView2.DataSource = ds1.Tables[0];

            //Burgers
            query2 = "SELECT mname AS 'Item Name', perUnit AS 'Price' FROM stock WHERE mnumber = 'Burgers'";
            DataSet ds2 = fn.getData(query2);
            dataGridView3.DataSource = ds2.Tables[0];

            //Fries
            query3 = "SELECT mname AS 'Item Name', perUnit AS 'Price' FROM stock WHERE mnumber = 'Fries'";
            DataSet ds3 = fn.getData(query3);
            dataGridView4.DataSource = ds3.Tables[0];

            //Sandwiches
            query4 = "SELECT mname AS 'Item Name', perUnit AS 'Price' FROM stock WHERE mnumber = 'Sandwiches'";
            DataSet ds4 = fn.getData(query4);
            dataGridView5.DataSource = ds4.Tables[0];

            //Desi
            query5 = "SELECT mname AS 'Item Name', perUnit AS 'Price' FROM stock WHERE mnumber = 'Desi'";
            DataSet ds5 = fn.getData(query5);
            dataGridView6.DataSource = ds5.Tables[0];

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
