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
    public partial class UserControl7 : UserControl
    {
        function fn = new function();
        String query;
        String query1;
        String query2;
        String query3;
        String query4;
        String query5;
        String query6;

        public UserControl7()
        {
            InitializeComponent();
        }

        private void UserControl7_Load(object sender, EventArgs e)
        {
            //1. group by
            query = "\tSELECT\r\n    mname,\r\n    SUM(quantity * perUnit) AS TotalSalesAmount\r\nFROM\r\n    stock\r\nGROUP BY\r\n    mname;";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
            //2. group by
            query1 = "\tSELECT\r\n    CustomerName AS UserName,\r\n    AVG(Rating) AS AverageRating,\r\n    COUNT(FeedbackID) AS FeedbackCount\r\nFROM\r\n    Feedback\r\nGROUP BY\r\n    CustomerName;";
            DataSet ds1 = fn.getData(query1);
            dataGridView2.DataSource = ds1.Tables[0];

            //4 table join
            query2 = "SELECT users.name, cart.itemName, stock.mname, Feedback.FeedbackText\r\nFROM users\r\nJOIN cart ON users.id = cart.userID\r\nJOIN stock ON cart.stockID = stock.id\r\nJOIN Feedback ON users.id = Feedback.CustomerName;";
            DataSet ds2 = fn.getData(query2);
            dataGridView3.DataSource = ds2.Tables[0];

            //4 table join
            query3 = "SELECT users.name, cart.itemName, stock.mname, stocklog.event_type, stocklog.event_timestamp, stocklog.event_description\r\nFROM users\r\nJOIN cart ON users.id = cart.userID\r\nJOIN stock ON cart.stockID = stock.id\r\nJOIN stocklog ON stock.id = stocklog.logID;";
            DataSet ds3 = fn.getData(query3);
            dataGridView4.DataSource = ds3.Tables[0];

            //3 table join
            query4 = "SELECT users.name, stock.mname, stocklog.event_type, stocklog.event_timestamp, stocklog.event_description\r\nFROM users\r\nJOIN cart ON users.id = cart.userID\r\nJOIN stock ON cart.stockID = stock.id\r\nJOIN stocklog ON stock.id = stocklog.logID;";
            DataSet ds4 = fn.getData(query4);
            dataGridView5.DataSource = ds4.Tables[0];

            //3 table join
            query5 = "SELECT users.name, cart.itemName, stock.mname, cart.quantity, cart.totalAmount\r\nFROM users\r\nJOIN cart ON users.id = cart.userID\r\nJOIN stock ON cart.stockID = stock.id;";
            DataSet ds5 = fn.getData(query5);
            dataGridView6.DataSource = ds5.Tables[0];
        }
    }
}
