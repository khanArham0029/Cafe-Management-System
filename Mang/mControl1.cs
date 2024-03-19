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
    public partial class mControl1 : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;
        Int64 count;
        public mControl1()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void mControl1_Load(object sender, EventArgs e)
        {
            loadChart();
        }
        public void loadChart()
        {
            query ="select count(mname) from stock where eDate >= getdate()";
            ds = fn.getData(query);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["VALID"].Points.AddXY("STOCK VALIDITY CHART",count);

            query = "select count(mname) from stock where eDate <= getdate()";
            ds = fn.getData(query);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["EXPIRED"].Points.AddXY("STOCK VALIDITY CHART", count);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["VALID"].Points.Clear();
            chart1.Series["EXPIRED"].Points.Clear();

            loadChart();
        }
    }
}
