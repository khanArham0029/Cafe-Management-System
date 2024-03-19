using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFP.Cust
{
    public partial class uControl3 : UserControl
    {
        function fn = new function();
        String query;
       
        public uControl3()
        {
            InitializeComponent();
        }

        private void uControl3_Load(object sender, EventArgs e)
        {

           
            LoadCartData();
        }

       

        private void LoadCartData()
        {
            try
            {
                // Replace "YourSelectQuery" with the actual query to retrieve data from the CART table
                string selectQuery = "SELECT * FROM CART";

                // Fetch data from the CART table
                DataSet ds = fn.getData(selectQuery);

                // Bind the DataTable to the DataGridView
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
