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

namespace DBFP.Mang
{
 

    public partial class mControl7 : UserControl
    {
        function fn = new function();
        String query;
        String query1;
        String query2;
        String query3;
        String query4;
        String query5;
        String query6;
        public mControl7()
        {
            InitializeComponent();
        }

        private void mControl7_Load(object sender, EventArgs e)
        {
            //1.2 table join 
            query = "SELECT stock.mname, stocklog.event_type, stocklog.event_timestamp, stocklog.event_description\r\nFROM stock\r\nJOIN stocklog ON stock.id = stocklog.logID;\r\n";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
            //2. group by
            query1 = "SELECT users.name, cart.itemName, cart.quantity, cart.totalAmount\r\nFROM users\r\nJOIN cart ON users.id = cart.userID;";
            DataSet ds1 = fn.getData(query1);
            dataGridView2.DataSource = ds1.Tables[0];

            //4 table join
            query2 = "SELECT sl.logID AS StockLogID, sl.event_type AS StockEventType, sl.event_timestamp AS StockEventTimestamp,\r\n       ul.logID AS UserLogID, ul.event_type AS UserEventType, ul.event_timestamp AS UserEventTimestamp,\r\n       u.name AS UserName\r\nFROM stocklog sl\r\nJOIN users u ON sl.logID = u.id\r\nJOIN userlog ul ON u.id = ul.logID;";
            DataSet ds2 = fn.getData(query2);
            dataGridView3.DataSource = ds2.Tables[0];

            //4 table join
            query3 = "SELECT ul.logID, ul.event_type, ul.event_timestamp, ul.event_description\r\nFROM userlog ul\r\nWHERE ul.logID IN (\r\n    SELECT logID FROM users u WHERE u.userRole = 'Admin'\r\n);\r\n";
            DataSet ds3 = fn.getData(query3);
            dataGridView4.DataSource = ds3.Tables[0];

            //3 table join
            query4 = "SELECT u.name AS UserName, COUNT(f.FeedbackID) AS FeedbackCount \r\nFROM users u \r\nLEFT JOIN Feedback f ON u.email = f.Email\r\nWHERE u.userRole = 'customer'\r\nGROUP BY u.name;\r\n";
            DataSet ds4 = fn.getData(query4);
            dataGridView5.DataSource = ds4.Tables[0];

            //3 table join
            query5 = "SELECT mname AS StockItem, SUM(quantity) AS TotalQuantity\r\nFROM stock\r\nGROUP BY mname;";
            DataSet ds5 = fn.getData(query5);
            dataGridView6.DataSource = ds5.Tables[0];

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
