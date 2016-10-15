using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SoapStudentCrudFuck
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
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
}
