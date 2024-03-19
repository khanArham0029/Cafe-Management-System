using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFP.Mang
{
    public partial class mControl3 : UserControl
    {

        function fn = new function();
        String query;


        public mControl3()
        {
            InitializeComponent();
        }

        private void mControl3_Load(object sender, EventArgs e)
        {
            query = "select * from stock";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            query = "select * from stock where mname like '" + textBox1.Text + "%'";

            setDataGV(query);
        }
        private void setDataGV(string query)
        {
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];


        }
        String sid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                sid= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("are you sure?","delete confirmation!",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                query = "delete from stock where mid = '"+sid+"'";
                fn.setData(query, "the record has been deleted");
                mControl3_Load(this, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mControl3_Load(this, null);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
