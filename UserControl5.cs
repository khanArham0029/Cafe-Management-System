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
    public partial class UserControl5 : UserControl
    {
        function fn = new function();
        String query;
        String query1;
        public UserControl5()
        {
            InitializeComponent();
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {
            //Juices
            query = "select * from userlog";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
            //Biscuits
            query1 = "select * from stocklog";
            DataSet ds1 = fn.getData(query1);
            dataGridView2.DataSource = ds1.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
