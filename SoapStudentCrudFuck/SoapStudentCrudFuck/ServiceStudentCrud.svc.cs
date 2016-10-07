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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceStudentCrud" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceStudentCrud.svc or ServiceStudentCrud.svc.cs at the Solution Explorer and start debugging.
    public class ServiceStudentCrud : IServiceStudentCRUD
    {
        string connectionString =
                @"Data Source=students-server.database.windows.net;Initial Catalog=Students;Integrated Security=False;User ID=chri56a4;Password=K03g3bugt;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static List<Student> _students = new List<Student>();

        /// <summary>
        /// Gets all students.
        /// </summary>
        public List<Student> GetAllStudents()
        {
            return DbHelper.GetAllStudents();
        }

        /// <summary>
        /// Gets a single student.
        /// Takes a student object as parameter.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student GetStudent(Student student)
        {
            return DbHelper.GetStudent(student);
        }

        /// <summary>
        /// Adds a student
        /// takes Student object as parameter.
        /// </summary>
        /// <param name="student"></param>
        public bool AddStudents(Student student)
        {
            if (DbHelper.AddStudents(student)) return true;
            return false;
        }
        /// <summary>
        /// Deletes a student
        /// Takes student object as parameter.
        /// </summary>
        /// <param name="student"></param>
        public bool DeleteStudent(Student student)
        {
            if (DbHelper.DeleteStudent(student)) return true;
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
            if (DbHelper.UpdateStudent(index, student)) return true;
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
            return DbHelper.GetStudentByFirstName(firstName);
        }
    }
}
