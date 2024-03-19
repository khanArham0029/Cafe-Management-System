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
    public partial class UserControl6 : UserControl
    {
        function fn = new function();
        String query;
        String query1;
        String query2;
        String query3;
        String query4;
        String query5;

        public UserControl6()
        {
            InitializeComponent();
        }

        private void UserControl6_Load(object sender, EventArgs e)
        {
            //Juices
            query = "SELECT * from UserCartReport";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
            //Biscuits
            query1 = "SELECT * from StockAvailabilityReport";
            DataSet ds1 = fn.getData(query1);
            dataGridView2.DataSource = ds1.Tables[0];

            //Burgers
            query2 = "SELECT * from UserFeedbackReport";
            DataSet ds2 = fn.getData(query2);
            dataGridView3.DataSource = ds2.Tables[0];

            //Fries
            query3 = "SELECT * from UserLoginHistoryReport";
            DataSet ds3 = fn.getData(query3);
            dataGridView4.DataSource = ds3.Tables[0];

            //Sandwiches
            query4 = "SELECT * from UserCartSummaryReport";
            DataSet ds4 = fn.getData(query4);
            dataGridView5.DataSource = ds4.Tables[0];
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
