using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GradeCalculator
{
    public partial class RetrieveGrade : UserControl
    {
        private string connectionString = "Server=DESKTOP-OR47OK3\\SQLEXPRESS; " +
            "Trusted_Connection=true;" +
            "Database=StudentDatabase;" +
            "User Instance=false;" +
            "Connection Timeout=30";

        public int StudentID { get; set; }

        public RetrieveGrade()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string letterGrade = string.Empty;
            string percentage = string.Empty;

            try
            {
                // Retrieve the Assignment ID from the TextBox
                if (!int.TryParse(textBoxAssignmentID.Text, out int assignmentID))
                {
                    MessageBox.Show("Please enter a valid assignment ID.");
                    return;
                }

                // Add the Course ID (150) as a parameter
                //int courseId = 150;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("GetStudentGradesWithoutCourse", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StudentID", StudentID);
                        command.Parameters.AddWithValue("@AssignmentID", assignmentID);

                        // Add the CourseID parameter to the SQL query
                        // command.Parameters.AddWithValue("@CourseID", courseId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                letterGrade = reader["LetterGrade"].ToString();
                                percentage = reader["GradePercentage"].ToString();
                                string maxPoints = reader["MaxPoints"].ToString();
                                string pointsEarned = reader["PointsEarned"].ToString();

                                lb_letterGradeRetrieve.Text = letterGrade;
                                lb_percentageRetrieve.Text = percentage + "%";
                                lb_gradePossible.Text = maxPoints;
                                lb_gradeEarned.Text = pointsEarned;
                            }
                            else
                            {
                                lb_letterGradeRetrieve.Text = "No data found";
                                lb_percentageRetrieve.Text = string.Empty;
                                lb_gradePossible.Text = string.Empty;
                                lb_gradeEarned.Text = string.Empty;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}

