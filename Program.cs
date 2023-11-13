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

namespace GradeTracker
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;

        public Form1()
        {
            InitializeComponent();
            ConnectToDatabase();
        }

        private void ConnectToDatabase()
        {
            try
            {
                string connectionString = "Data Source=(local);InitialCatalog=GradeTracker;Integrated Security=True";
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
            }
        }

        private void InsertGradeButton_Click(object sender, EventArgs e)
        {
            try
            {
                int studentId = int.Parse(StudentIdTextBox.Text);
                int assignmentId = int.Parse(AssignmentIdTextBox.Text);
                int grade = int.Parse(GradeTextBox.Text);

                InsertGrade(studentId, assignmentId, grade);

                MessageBox.Show("Grade inserted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting grade: " + ex.Message);
            }
        }

        private void RetrieveGradesButton_Click(object sender, EventArgs e)
        {
            try
            {
                RetrieveGrades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving grades: " + ex.Message);
            }
        }

        private void InsertGrade(int studentId, int assignmentId, int grade)
        {
            string query = "INSERT INTO StudentGrade (StudentID, AssignmentID, Grade) VALUES (@studentId, @assignmentId, @grade)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentId", studentId);
            command.Parameters.AddWithValue("@assignmentId", assignmentId);
            command.Parameters.AddWithValue("@grade", grade);
            command.ExecuteNonQuery();
        }

        private void RetrieveGrades()
        {
            string query = "SELECT * FROM StudentGrade";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                GradesListBox.Items.Add($"Student ID: {reader["StudentID"]}, Assignment ID: {reader["AssignmentID"]}, Grade: {reader["Grade"]}");
            }

            reader.Close();
        }

        // Don't forget to close the connection when the form is closed
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            connection?.Close();
        }
    }
}



