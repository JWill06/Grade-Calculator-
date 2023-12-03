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

namespace GradeCalculator
{
    // Replace with your actual connection string
        string connectionString = "Server=; " +
            "Trusted_Connection=true;" +
            "Database=StudentDatabase;" +
            "User Instance=false;" +
            "Connection Timeout=30";

        // Remove the hard-coded value
        public int StudentID { get; set; } = 2;

        // Set to a known good CourseID for testing
        public int CourseID = 101;

        public OverallGrade()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetOverallStudentGrade", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StudentID", StudentID);
                        command.Parameters.AddWithValue("@CourseID", CourseID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string overallLetterGrade = reader["OverallLetterGrade"].ToString();
                                string overallPercentage = reader["OverallGradePercentage"].ToString();

                                lb_letterGradeOverall.Text = overallLetterGrade;
                                lb_percentageOverall.Text = overallPercentage + "%";
                            }
                            else
                            {
                                lb_letterGradeOverall.Text = "No data found";
                                lb_percentageOverall.Text = "No data found";
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("General Error: " + ex.Message);
            }
        }
    }
}
