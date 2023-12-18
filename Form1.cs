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
    public partial class Form1 : Form
    {
        DB database;
        public Form1()
        {
            InitializeComponent();

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            enterGrade1.Hide();
            retrieveGrade1.Hide();
            overallGrade1.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Hide other user controls
            retrieveGrade1.Hide();
            overallGrade1.Hide();
            //Show the user control
            enterGrade1.Show();
            enterGrade1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Hide other user controls
            enterGrade1.Hide();
            overallGrade1.Hide();
            //Show the user control
            retrieveGrade1.Show();
            retrieveGrade1.BringToFront();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Hide other user controls
            enterGrade1.Hide();
            retrieveGrade1.Hide();
            //Show the user control
            overallGrade1.Show();
            overallGrade1.BringToFront();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            database = new DB("Server=DESKTOP-PVPHME7\\SQLEXPRESS;Database=StudentDatabase;Integrated Security=True; " +
                   "Trusted_Connection=true;" +
                   "Database=StudentDatabase;" +
                   "User Instance=false;" +
                   "Connection Timeout=30");

            int StudentID = int.Parse(textBox1.Text);
            string studentName = "";
            studentName = database.GetStudentName(StudentID);
            retrieveGrade1.StudentID = StudentID;
            overallGrade1.StudentID = StudentID;


            if (studentName == null)
            {
                MessageBox.Show("Invalid student ID or student does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // textBox1.Text = StudentID;
            else
            {
                lb_Name.Text = "";
                lb_Name.Text = studentName;

                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
            }
        }
    }
}
