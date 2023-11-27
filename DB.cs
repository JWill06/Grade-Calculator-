using System;
using System.Collections.Generic;
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
        SqlConnection cnn;

        public DB()
        {
            connectionString = "Server = WARDWINDOWS; " +
                               "Trusted_Connection=true;" +
                               "Database=StudentDatabase;" +
                               "User Instance=false;" +
                               "Connection Timeout=30";
        }

        public DB(string conn)
        {
            connectionString = conn;
        }

        public string GetStudentName(int StudentID)
        {
            string query = "SELECT FirstName, LastName FROM Student WHERE StudentID = @StudentID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", StudentID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    string firstName = "";
                    string lastName = "";
                    
                    if (reader.Read())
                    {
                        firstName = reader.GetString(0);
                        lastName = reader.GetString(1);
                    }

                    reader.Close();
                    connection.Close();
                    if (firstName == "" && lastName == "")
                    {
                        MessageBox.Show("Invalid student ID or student does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                    else
                    {
                        return firstName + " " + lastName;
                    }
                }
            }
        }

        //change storedProcedureName
        public double CalculateOverallPercentage(string storedProcedureName)
        {
            double percentage = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    connection.Open();
                    percentage = (double)command.ExecuteScalar();
                    connection.Close();
                }
            }

            return percentage;
        }
    }
}
