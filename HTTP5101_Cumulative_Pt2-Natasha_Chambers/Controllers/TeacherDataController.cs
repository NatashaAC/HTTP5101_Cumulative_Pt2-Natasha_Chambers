using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HTTP5101_Cumulative_Pt2_Natasha_Chambers.Models;
using MySql.Data.MySqlClient;

namespace HTTP5101_Cumulative_Pt2_Natasha_Chambers.Controllers
{
    public class TeacherDataController : ApiController
    {
        // Context Class that allows access to the School Database
        private SchoolDbContext School = new SchoolDbContext();

        // Objective: 
        // Access the data stored in the teachers table
        /// <summary>
        ///     Returns a list of the data within the teachers table
        ///     in the school database
        /// </summary>
        /// <returns> A list of teachers (first name, last name, employee number, hire date, salary)</returns>
        /// <example>
        ///     GET api/TeacherData/ListTeachers
        /// </example>
        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{SearchKey?}")]
        public IEnumerable<Teacher> ListTeachers(string SearchKey = null)
        {
            // Instance of Connection
            MySqlConnection Conn = School.AccessDatabase();

            // Open connection between web server and database
            Conn.Open();

            // Create new query for database
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL Query
            cmd.CommandText = "SELECT * FROM teachers WHERE LOWER(teacherfname) LIKE LOWER(@key) " +
                "OR LOWER(teacherlname) LIKE LOWER(@key) " +
                "OR LOWER(CONCAT(teacherfname, ' ', teacherlname)) LIKE LOWER(@key)";

            // Parameters to protect Query from SQL Injection Attacks
            cmd.Parameters.AddWithValue("key", "%" + SearchKey + "%");
            cmd.Prepare();

            // Variable that stores the results from the SQL Query
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // Empty list of Teachers
            List<Teacher> Teachers = new List<Teacher> { };

            // Loop through Result Set rows and add to teachers list
            while (ResultSet.Read())
            {
                // New Teacher Object
                Teacher NewTeacher = new Teacher();

                // Access the Columns in the Teachers table
                NewTeacher.TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                NewTeacher.TeacherFname = ResultSet["teacherfname"].ToString();
                NewTeacher.TeacherLname = ResultSet["teacherlname"].ToString();
                NewTeacher.EmployeeNumber = ResultSet["employeenumber"].ToString();
                NewTeacher.HireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                NewTeacher.Salary = Convert.ToDecimal(ResultSet["salary"]);

                // Add the NewTeacher to empty list
                Teachers.Add(NewTeacher);
            }

            // Close connection
            Conn.Close();

            // Return populated list
            return Teachers;
        }

        /// <summary>
        ///     Returns the information of a teacher based on the teacher id 
        /// </summary>
        /// <param name="id"> an interger </param>
        /// <returns> A teacher </returns>
        /// <example> GET api/TeacherData/FindTeacher/4 </example>
        [HttpGet]
        [Route("api/TeacherData/FindTeacher/{id}")]
        public Teacher FindTeacher(int id)
        {
            // New Teacher Object
            Teacher NewTeacher = new Teacher();

            // Access School database
            MySqlConnection Conn = School.AccessDatabase();

            // Open connection
            Conn.Open();

            // New query for School database
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL Query
            cmd.CommandText = "SELECT * FROM Teachers WHERE teacherid = " + id;

            // Store Query results
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // Loop through rows
            while (ResultSet.Read())
            {
                // Access Columns in Teachers Table
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                DateTime HireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                decimal Salary = Convert.ToDecimal(ResultSet["salary"]);

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
            }

            // Close Connection
            Conn.Close();

            return NewTeacher;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        public void DeleteTeacher(int id)
        {
            // Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            // Open the connection between the web server and database
            Conn.Open();

            // Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL Query
            cmd.CommandText = "DELETE FROM teachers WHERE teacherid = @id";

            // Parameters to protect against SQL Injection Attacks
            cmd.Parameters.AddWithValue("id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            // Close connection
            Conn.Close();
        }
    }
}
