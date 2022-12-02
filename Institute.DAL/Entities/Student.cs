using Institute.DAL.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Institute.DAL.Entities
{
    [Table("Students", Schema = "dbo")]

    public class Student : Person
    {
        [Key]
        public int Id { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        
    }
}