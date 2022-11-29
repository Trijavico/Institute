using Institute.DAL.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Institute.DAL.Entities
{
    [Table("Instructors", Schema = "dbo")]
    public class Professor
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
