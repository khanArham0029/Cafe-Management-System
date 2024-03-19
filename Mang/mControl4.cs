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
using static System.Windows.Forms.AxHost;

namespace DBFP.Mang
{
    public partial class mControl4 : UserControl
    {
        function fn = new function();
        String query;

        public mControl4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                query = "select * from stock where mid = '"+textBox1.Text+"'";
                DataSet ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count != 0) 
                { 
                
                textBox2.Text=   ds.Tables[0].Rows[0][2].ToString();
                comboBox1.Text = ds.Tables[0].Rows[0][3].ToString();
                dateTimePicker2. Text = ds.Tables[0].Rows[0][4].ToString();
                dateTimePicker1. Text = ds.Tables[0].Rows[0][5].ToString();
                textBox4.Text =  ds.Tables[0].Rows[0][6].ToString();
                textBox5.Text =  ds.Tables[0].Rows[0][7].ToString();



                }
                else
                {

                    MessageBox.Show("no food with ID","info",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                clearAll();
            }
        }

        public void clearAll()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            dateTimePicker2.ResetText();
            dateTimePicker1.ResetText();
            textBox4.Clear();
            textBox5.Clear();
            textBox3.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        Int64 totalQuantity;
        private void button2_Click(object sender, EventArgs e)
        {
            String mname = textBox2.Text;
            String mnumber = comboBox1.Text;
            String edate = dateTimePicker1.Text;
            String mdate = dateTimePicker2.Text;
            Int64 quantity = Int64.Parse(textBox4.Text);
            Int64 addquantity = Int64.Parse(textBox3.Text);
            Int64 unitprice = Int64.Parse(textBox5.Text);
            totalQuantity = quantity+addquantity;

            // mid,mname,mnumber,mDate,eDate,quantity,perUnit


            query = "update stock set mname ='"+mname+"', mnumber = '"+mnumber+"',mDate ='"+mdate+"', eDate ='"+edate+"', quantity = "+totalQuantity+", perUnit = "+unitprice+" where mid ='"+textBox1.Text+"'  ";
            fn.setData(query,"stock details updated");





        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
