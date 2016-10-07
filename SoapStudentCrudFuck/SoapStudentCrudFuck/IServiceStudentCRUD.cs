using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SoapStudentCrudFuck
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceStudentCRUD" in both code and config file together.
    [ServiceContract]
    public interface IServiceStudentCRUD
    {
        [OperationContract]
        Student GetStudent(Student student);
        [OperationContract]
        List<Student> GetAllStudents();
        [OperationContract]
        List<Student> GetStudentByFirstName(string firstName);  
        [OperationContract]
        bool AddStudents(Student student);
        [OperationContract]
        bool UpdateStudent(int index, Student student);
        [OperationContract]
        bool DeleteStudent(Student student);

        
    }


    // Use a data contract as illustrated in the sample below to add student types to service operations.
    [DataContract]
    public class Student
    {
        private string _cpr;

        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string Cpr
        {
            get { return _cpr; }
            set { _cpr = value; }
        }

        public override bool Equals(object obj)
        {
            Student studentObj = (Student)obj;
            if (obj.GetType() != typeof(Student)) return false;
            else
            {
                if (Cpr.Equals(studentObj.Cpr)) return true;
            }
            return false;
        }
    }
}
