using System;
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
    public partial class uControl4 : UserControl
    {
        function fn = new function();
        String query;
        
        
        private string connectionString = "Your_Connection_String";

        public uControl4()
        {
            InitializeComponent();
        }

        private void uControl4_Load(object sender, EventArgs e)
        {
            // Additional initialization code can be added here if needed
        }

       

        private void InsertFeedback(string customerName, string email, string feedbackText, int rating)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to insert feedback into the Feedback table
                    string query = "INSERT INTO Feedback (CustomerName, Email, FeedbackText, Rating, FeedbackDate) " +
                                   "VALUES (@CustomerName, @Email, @FeedbackText, @Rating, GETDATE())";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SQL query
                        command.Parameters.AddWithValue("@CustomerName", customerName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@FeedbackText", feedbackText);
                        command.Parameters.AddWithValue("@Rating", rating);

                        // Execute the SQL query
                        command.ExecuteNonQuery();

                        MessageBox.Show("Feedback submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting feedback: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get user input
            string customerName = textBox1.Text;
            string email = textBox2.Text;
            string feedbackText = textBox3.Text;
            int rating = (int)numericUpDown1.Value; // Assuming you have a NumericUpDown control for rating

            query = "INSERT INTO Feedback (CustomerName, Email, FeedbackText, Rating, FeedbackDate) VALUES ('"+ customerName + "','"+ email + "','"+ feedbackText + "',"+ rating + ", GETDATE())";
            fn.setData(query, "Thank you for your Feedback brother");

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

