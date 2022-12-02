
using Institute.BLL.Core;

namespace Institute.BLL.Dto.Department
{
    public class DepartmentUpdateDto : DepartmentDtoBase
    {
        public int DepartmentID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int CourseID { get; set; }
    }
}
