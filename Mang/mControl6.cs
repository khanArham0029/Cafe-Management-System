using DGVPrinterHelper;
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
    public partial class mControl6 : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;

        public mControl6()
        {
            InitializeComponent();
        }

        private void mControl6_Load(object sender, EventArgs e)
        {
            // here we will display the item in list box from the stock table 
            listBox1.Items.Clear();   
            query = "select mname AS ItemName from stock where eDate >= getdate() and quantity >= '0'";
            ds = fn.getData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // this is a refresh button so that if new stock is added it can be loaded to listbox
            mControl6_Load(this,null);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // this is a textbox from where you can search items in the list box as you type
            listBox1.Items.Clear();
            query ="select mname from stock where mname like '"+textBox1.Text+"%' and eDate >= getdate() and quantity > '0'";
            ds = fn.getData(query) ;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // in this function when we click on any index in listbox1 it gets it eDate perunit mid from stock where index = mname
            textBox5.Clear();

            String name = listBox1.GetItemText(listBox1.SelectedItem);

            textBox4.Text = name;

            query = "select mid,eDate,perUnit from stock where mname ='"+name+"' ";
            ds = fn.getData(query) ;
            textBox2.Text = ds.Tables[0].Rows[0][0].ToString(); 
            dateTimePicker1.Text = ds.Tables[0].Rows[0][1].ToString();
            textBox3.Text = ds.Tables[0].Rows[0][2].ToString();


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // this will take the quantity and add the value in textbox6 which is for total price
            if(textBox5.Text != "")
            {
                Int64 unitPrice = Int64.Parse(textBox3.Text);
                Int64 noOfUnit = Int64.Parse(textBox5.Text);
                Int64 totalAmount = noOfUnit* unitPrice;
                textBox6.Text = totalAmount.ToString();


            }
            else
            {
                textBox6.Clear();

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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //this is to select an item from datagrid view 
                valueAmount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                valueID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                noOfunit = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            catch(Exception)
            { }

        }

        private void button2_Click(object sender, EventArgs e)
        {   
            // if you click on this button the below working will add the data of the stock selected and display it into the datagridview
            if(textBox2.Text != "")
            {

                query = "select quantity from stock where mid = '"+textBox2.Text+"'";
                ds = fn.getData(query) ;

                quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                newQuantity = quantity - Int64.Parse(textBox5.Text);

                if(newQuantity > 0)
                {
                    n = dataGridView1.Rows.Add();

                    dataGridView1.Rows[n].Cells[0].Value = textBox2.Text;
                    dataGridView1.Rows[n].Cells[1].Value = textBox4.Text;
                    dataGridView1.Rows[n].Cells[2].Value = dateTimePicker1.Text;
                    dataGridView1.Rows[n].Cells[3].Value = textBox3.Text;
                    dataGridView1.Rows[n].Cells[4].Value = textBox5.Text;
                    dataGridView1.Rows[n].Cells[5].Value = textBox6.Text;

                    totalAmount = totalAmount + int.Parse(textBox6.Text);

                    label8.Text = "Rs. " + totalAmount.ToString() ;

                    query = "update stock set quantity = '"+newQuantity+"' where mid = '"+textBox2.Text+"'  ";
                    fn.setData(query, "data updated brother");
                }
                else
                {
                    MessageBox.Show("Medicine is out of stock","sad",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                clearAll();
                mControl6_Load(this, null);


            }
            else
            {
                MessageBox.Show("select item fist","oops",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            
        }

       

        private void clearAll()
        {
            //this will clear all text boxes
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

     

        private void button1_Click(object sender, EventArgs e)
        {
            //this button will remove the selected item from datagrid view
            if(valueID != null)
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
                    query ="select quantity from stock where mid = '"+valueID+"' ";
                    ds = fn.getData(query);
                    quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    newQuantity= quantity+noOfunit;

                    query = "update stock set quantity = '"+newQuantity+"' where mid = '"+valueID+"'  ";
                    fn.setData(query, "item removed");
                    totalAmount = totalAmount - valueAmount;
                    label8.Text = "Rs." + totalAmount.ToString();




                }
                mControl6_Load(this, null);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "CAFE BILL TOTAL";
            print.SubTitle = String.Format("Date:-{0}",DateTime.Now.Date);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Total payable Amount : "+label8.Text;
            print.FooterSpacing = 15;
            print.PrintDataGridView(dataGridView1);


            totalAmount = 0;
            label8.Text = "Rs. 00";
            dataGridView1.DataSource = 0;

        }
    }
}
