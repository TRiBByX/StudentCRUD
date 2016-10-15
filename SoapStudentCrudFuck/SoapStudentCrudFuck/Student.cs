using System.Runtime.Serialization;

namespace SoapStudentCrudFuck
{
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

        //public override bool Equals(object obj)
        //{
        //    Student studentObj = (Student)obj;
        //    if (obj.GetType() != typeof(Student)) return false;
        //    else
        //    {
        //        if (Cpr.Equals(studentObj.Cpr)) return true;
        //    }
        //    return false;
        //}
    }
}