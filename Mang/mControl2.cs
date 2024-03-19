using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace DBFP.Mang
{
    public partial class mControl2 : UserControl
    {
        function fn = new function();
        String query;

        public mControl2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                String mid =     textBox1.Text;
                String mname =   textBox2.Text;
                String mnumber = comboBox1.Text;
                String mdate =   dateTimePicker2.Text;
                String edate =   dateTimePicker1.Text;
                Int64 quantity = Int64.Parse(textBox4.Text);
                Int64 perunit =  Int64.Parse(textBox5.Text);

                query = "insert into stock (mid,mname,mnumber,mDate,eDate,quantity,perUnit) values ('"+mid+"','"+mname+"','"+mnumber+"','"+mdate+"','"+edate+"',"+quantity+","+perunit+")";

                fn.setData(query, "Stock updated brother");
            }

            else
            {

                MessageBox.Show("Enter all Data.","Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        public void clearAll()
        {

            textBox1.Clear();

            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();

            comboBox1.SelectedIndex = -1;

            dateTimePicker2.ResetText();
            dateTimePicker1.ResetText();

        }

        private void mControl2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
