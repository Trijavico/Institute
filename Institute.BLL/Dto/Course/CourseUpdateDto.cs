using Institute.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.BLL.Dto.Course
{
    public class CourseUpdateDto : CourseDtoBase
    {
        public int CourseID { get; set; }
        public int DepartmentID { get; internal set; }
    }
}
