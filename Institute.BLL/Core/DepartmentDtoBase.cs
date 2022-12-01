using System.Data.SqlTypes;

namespace Institute.BLL.Core
{
    public class DepartmentDtoBase : DtoAudit
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime? StartDate { get; set; }
        public int Administrator { get; set; }
    }
}
