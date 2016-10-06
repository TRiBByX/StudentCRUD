using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SoapStudentCrudFuck
{
    public class DbHelper
    {
        static string connectionString =
            @"Data Source=students-server.database.windows.net;Initial Catalog=Students;Integrated Security=False;User ID=chri56a4;Password=K03g3bugt;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Student> GetAllStudents()
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

        public static List<Student> GetStudentByFirstName(string firstName)
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

        public static bool UpdateStudent(int index, Student student)
        {
            string queryString =
                $"UPDATE * [Table] SET firstName='{student.FirstName}', lastName='{student.LastName}', cpr='{student.Cpr}', age='{student.Age}'";
            if (DBCommand(queryString)) return true;
            return false;
        }

        public static bool DeleteStudent(Student student)
        {
            string queryString =
                $"DELETE * FROM [Table] WHERE cpr='{student.Cpr}'";

            if (DBCommand(queryString)) return true;
            return false;
        }

        public static Student GetStudent(Student s)
        {
            string queryString = $"SELECT * FROM [Table] WHERE cpr = '{s.Cpr}'";
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

        public static bool AddStudents(Student student)
        {
            string queryString =
                $"INSERT INTO [Table] values ('{student.FirstName}', '{student.LastName}','{student.Cpr}','{student.Age}')";
            if (DBCommand(queryString)) return true;
            return false;
        }
        /// <summary>
        /// Connects to the database, and gives it the query string.
        /// takes a string containing an SQL query as parameter.  
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        private static bool DBCommand(string queryString)
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