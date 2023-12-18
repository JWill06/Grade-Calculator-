using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeCalculator
{
    class DB
    {
        string connectionString;
        
        public DB()
        {
            connectionString = "Data Source=DESKTOP-PVPHME7\\SQLEXPRESS;" +
                               "Trusted_Connection=true;" +
                               "Database=StudentDatabase;" +
                               "User Instance=false;" +
                               "Connection Timeout=30";
        }

        public DB(string conn)
        {
            connectionString = conn;
        }

        public string GetStudentName(int studentID)
        {
            string query = "SELECT FirstName, LastName FROM Student WHERE StudentID = @StudentID";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string firstName = reader.GetString(0);
                                string lastName = reader.GetString(1);
                                return $"{firstName} {lastName}";
                            }
                            else
                            {
                                MessageBox.Show("Invalid student ID or student does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"General Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

