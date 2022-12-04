using Institute.DAL.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace Institute.DAL.Entities
{
    public class Department : BaseEntity
    {

        public int DepartmentID { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int Administrator { get; set; }
        public int CourseID { get; set; }
    }
}