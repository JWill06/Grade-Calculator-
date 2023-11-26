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
    public partial class RetrieveGrade : UserControl
    {

        private string connectionString = "YourConnectionString";

        public RetrieveGrade()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string storedProcedureName = "YourStoredProcedureName";

            // Retrieves grades from the stored procedure
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add any required parameters to the command, if necessary
                    // command.Parameters.AddWithValue("@parameterName", parameterValue);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Retrieve grades from the reader and process them as needed
                            var grade = reader.GetString(0); 
                        }
                    }
                }
            }
        }

    }
}

