using Institute.BLL.Dto.Course;
using Institute.BLL.Dto.Department;
using Institute.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.BLL.Extensions
{
    public static class CourseExtension
    {
        public static Course FromCrsSaveToEntity(this CourseSaveDto courseSave)
        {
            return new Course()
            {
                Title = courseSave.Title,
                Credits = courseSave.Credits,
                CourseID = courseSave.CourseID,
                DepartmentID = courseSave.DepartmentID
            };
        }

        public static Course FromCrsUpdateToEntity(this CourseUpdateDto courseUpdate)
        {
            return new Course()
            {
                Title = courseUpdate.Title,
                Credits = courseUpdate.Credits,
                CourseID = courseUpdate.CourseID,
                DepartmentID = courseUpdate.DepartmentID
            };
        }
    }
}

