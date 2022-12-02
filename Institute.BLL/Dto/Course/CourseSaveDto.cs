using Institute.BLL.Core;

namespace Institute.BLL.Dto.Course
{
    public class CourseSaveDto : CourseDtoBase
    {
        public int CourseID { get; set; }
        public int DepartmentID { get; internal set; }
    }
}
