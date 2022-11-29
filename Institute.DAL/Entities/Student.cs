using Institute.DAL.Core;

namespace Institute.DAL.Entities
{
    public class Student : Person
    {
        public int Id { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}