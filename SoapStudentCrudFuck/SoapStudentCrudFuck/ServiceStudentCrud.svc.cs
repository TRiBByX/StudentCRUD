using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SoapStudentCrudFuck
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        string connectionString =
                @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CloudStudent;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        /// <summary>
        /// Gets all students.
        /// </summary>
        public List<Student> GetAllStudents()
        {
            string queryString = $"SELECT * FROM [Table]";
            var studentList = new List<Student>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(queryString, connection);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var s = new Student();
                    s.FirstName = reader.GetString(1);
                    s.LastName = reader.GetString(2);
                    s.Cpr = reader.GetString(3);
                    s.Age = reader.GetInt32(4);
                    studentList.Add(s);
                }
                connection.Close();
                return studentList;
            }
            return null;
        }

        /// <summary>
        /// Gets a single student.
        /// Takes a student object as parameter.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student GetStudent(Student student)
        {
            string queryString = $"SELECT * FROM [Table] WHERE cpr = '{student.Cpr}'";
            var returnStudent = new Student();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(queryString, connection);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    returnStudent.FirstName = reader.GetString(1);
                    returnStudent.LastName = reader.GetString(2);
                    returnStudent.Cpr = reader.GetString(3);
                    returnStudent.Age = reader.GetInt32(4);
                }
                connection.Close();
                return returnStudent;
            }
            return null;
        }

        /// <summary>
        /// Adds a student
        /// takes Student object as parameter.
        /// </summary>
        /// <param name="student"></param>
        public bool AddStudents(Student student)
        {
            string queryString =
                $"INSERT INTO [Table] values ('{student.FirstName}', '{student.LastName}','{student.Cpr}','{student.Age}')";
            if (DBCommand(queryString)) return true;
            return false;
        }
        /// <summary>
        /// Deletes a student
        /// Takes student object as parameter.
        /// </summary>
        /// <param name="student"></param>
        public bool DeleteStudent(Student student)
        {
            string queryString =
               $"DELETE * FROM [Table] WHERE cpr='{student.Cpr}'";

            if (DBCommand(queryString)) return true;
            return false;
        }
        /// <summary>
        /// Updates a student.
        /// Takes student object as new student, and int as index of old student
        /// </summary>
        /// <param name="index"></param>
        /// <param name="student"></param>
        public bool UpdateStudent(int index, Student student)
        {
            string queryString = $"UPDATE * [Table] SET firstName='{student.FirstName}', lastName='{student.LastName}', cpr='{student.Cpr}', age='{student.Age}'";
            if (DBCommand(queryString)) return true;
            return false;
        }

        /// <summary>
        /// Creates a list of students based on the first name.
        /// Takes a string (firstName) as parameter.
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public List<Student> GetStudentByFirstName(string firstName)
        {
            string queryString = $"SELECT * FROM [Table] WHERE firstName = '{firstName}'";
            List<Student> tobeReturnedList = new List<Student>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(queryString, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student s = new Student();
                    s.FirstName = reader.GetString(1);
                    s.LastName = reader.GetString(2);
                    s.Cpr = reader.GetString(3);
                    s.Age = reader.GetInt32(4);
                    tobeReturnedList.Add(s);
                }
                return tobeReturnedList;
            }
        }

        /// <summary>
        /// Connects to the database, and gives it the query string.
        /// takes a string containing an SQL query as parameter.  
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public bool DBCommand(string queryString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand();

                cmd.CommandText = queryString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                connection.Open();
                cmd.ExecuteReader();

                connection.Close();
                return true;
            }
        }
    }
}
