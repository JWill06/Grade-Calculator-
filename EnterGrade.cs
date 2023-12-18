using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeCalculator
{
    public partial class EnterGrade : UserControl
    {
        public EnterGrade()
        {
            InitializeComponent();
        }

        string connectionString = "Server=DESKTOP-PVPHME7\\SQLEXPRESS;Database=StudentDatabase;Integrated Security=True; " +
            "Trusted_Connection=true;" +
            "Database=StudentDatabase;" +
            "User Instance=false;" +
            "Connection Timeout=30";

        private void button1_Click(object sender, EventArgs e)
        {
            string assignment = txtAssignment.Text;
            int pointsEarned, pointsPossible;

            if (!int.TryParse(txtPointsEarned.Text, out pointsEarned) || !int.TryParse(txtPointsPossible.Text, out pointsPossible))
            {
                MessageBox.Show("Invalid input for points earned or points possible. Please enter valid numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //Add the Course ID (150) as a parameter
                int courseId = 101;
                int studentId = 1;
                int assignmentId = int.Parse(txtAssignment.Text);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    //Check if PK value already exists
                    using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM dbo.Assignment WHERE AssignmentID = @AssignmentID AND CourseID = @CourseID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@AssignmentID", assignmentId);
                        checkCommand.Parameters.AddWithValue("@StudentID", studentId);
                        checkCommand.Parameters.AddWithValue("@CourseID", courseId);

                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            //a record with the sam PK already exists
                            MessageBox.Show("A record for this assignment already exists");
                        }
                        else
                        {
                            //No record of same PK 

                            using (SqlCommand command = new SqlCommand("INSERT INTO Assignment (AssignmentID, AssignmentName,  StudentID, PointsEarned, MaxPoints, CourseID) VALUES (@AssignmentID, @AssignmentName, @StudentID, @PointsEarned, @MaxPoints, @CourseID)", connection))
                            {
                                command.Parameters.AddWithValue("@AssignmentID", assignmentId);
                                command.Parameters.AddWithValue("@AssignmentName", assignment);
                                command.Parameters.AddWithValue("@StudentID", studentId);
                                command.Parameters.AddWithValue("@PointsEarned", pointsEarned);
                                command.Parameters.AddWithValue("@MaxPoints", pointsPossible);
                                command.Parameters.AddWithValue("@CourseID", courseId);

                                //command.ExecuteNonQuery();
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Grade submitted successfully.");
                                }
                                else
                                {
                                    MessageBox.Show("Error submitting grade");
                                }
                            }

                            //MessageBox.Show("Grade submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    //catch (Exception ex)
                    //{
                    //MessageBox.Show("Error submitting grade: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting grade: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
