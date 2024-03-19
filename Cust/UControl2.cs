using DGVPrinterHelper;
using Microsoft.VisualBasic.ApplicationServices;
using System;
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
    public partial class UControl2 : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;

        public UControl2()
        {
            InitializeComponent();
        }

        private void UControl2_Load(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            query = "select mname AS ItemName from stock where eDate >= getdate() and quantity >= '0'";
            ds = fn.getData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }

        }







        /// <summary>
        /// data grid from this part onwards
        /// </summary>
        protected int n, totalAmount = 0;
        protected Int64 quantity, newQuantity;



        int valueAmount;
        String valueID;
        protected Int64 noOfunit;




        private void clearAll()
        {

            textBox2.Clear();
            textBox6.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dateTimePicker1.ResetText();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            query = "select mname from stock where mname like '" + textBox1.Text + "%' and eDate >= getdate() and quantity > '0'";
            ds = fn.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            UControl2_Load(this, null);
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox5.Clear();

            String name = listBox1.GetItemText(listBox1.SelectedItem);

            textBox4.Text = name;

            query = "select mid,eDate,perUnit from stock where mname ='" + name + "' ";
            ds = fn.getData(query);
            textBox2.Text = ds.Tables[0].Rows[0][0].ToString();
            dateTimePicker1.Text = ds.Tables[0].Rows[0][1].ToString();
            textBox3.Text = ds.Tables[0].Rows[0][2].ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                Int64 unitPrice = Int64.Parse(textBox3.Text);
                Int64 noOfUnit = Int64.Parse(textBox5.Text);
                Int64 totalAmount = noOfUnit * unitPrice;
                textBox6.Text = totalAmount.ToString();


            }
            else
            {
                textBox6.Clear();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                valueAmount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                valueID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                noOfunit = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            catch (Exception)
            { }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "CAFE BILL TOTAL";
            print.SubTitle = String.Format("Date:-{0}", DateTime.Now.Date);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Total payable Amount : " + label8.Text;
            print.FooterSpacing = 15;
            print.PrintDataGridView(dataGridView1);


            totalAmount = 0;
            label8.Text = "Rs. 00";
            dataGridView1.DataSource = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                // Retrieve the selected item details
                string itemID = textBox2.Text;
                string itemName = textBox4.Text; // New column added for item name
                string date = dateTimePicker1.Text;
                string perUnit = textBox3.Text;
                string quantity = textBox5.Text;
                string totalAmount = textBox6.Text;

                // Insert the selected item into the CART table
                string insertQuery = $"INSERT INTO CART (userID, stockID, itemName, quantity, totalAmount, purchaseDate) VALUES ('{2002}', '{2}', '{itemName}', '{quantity}', '{totalAmount}', '{date}')";
                fn.setData(insertQuery, "Item added to cart");

                // Clear all textboxes
                clearAll();
            }
            else
            {
                MessageBox.Show("Select an item first", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ////////////////////////////////////////////////////////////////
        //////////////////////////
        //////////////////////////////////////////
        //////////////////


        private void button1_Click(object sender, EventArgs e)
        {
            if (valueID != null)
            {
                try
                {
                    dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                }
                catch
                {

                }
                finally
                {
                    query = "select quantity from stock where mid = '" + valueID + "' ";
                    ds = fn.getData(query);
                    quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    newQuantity = quantity + noOfunit;

                    query = "update stock set quantity = '" + newQuantity + "' where mid = '" + valueID + "'  ";
                    fn.setData(query, "item removed");
                    totalAmount = totalAmount - valueAmount;
                    label8.Text = "Rs." + totalAmount.ToString();




                }
                UControl2_Load(this, null);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {

                query = "select quantity from stock where mid = '" + textBox2.Text + "'";
                ds = fn.getData(query);

                quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                newQuantity = quantity - Int64.Parse(textBox5.Text);

                if (newQuantity > 0)
                {
                    n = dataGridView1.Rows.Add();

                    dataGridView1.Rows[n].Cells[0].Value = textBox2.Text;
                    dataGridView1.Rows[n].Cells[1].Value = textBox4.Text;
                    dataGridView1.Rows[n].Cells[2].Value = dateTimePicker1.Text;
                    dataGridView1.Rows[n].Cells[3].Value = textBox3.Text;
                    dataGridView1.Rows[n].Cells[4].Value = textBox5.Text;
                    dataGridView1.Rows[n].Cells[5].Value = textBox6.Text;

                    totalAmount = totalAmount + int.Parse(textBox6.Text);

                    label8.Text = "Rs. " + totalAmount.ToString();

                    query = "update stock set quantity = '" + newQuantity + "' where mid = '" + textBox2.Text + "'  ";
                    fn.setData(query, "data updated brother");
                }
                else
                {
                    MessageBox.Show("Medicine is out of stock", "sad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                clearAll();
                UControl2_Load(this, null);


            }
            else
            {
                MessageBox.Show("select item fist", "oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



    }
}
