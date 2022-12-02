using Institute.BLL.Models;
using Institute.web.Models;
using System.Data.SqlTypes;

namespace Institute.web.Extensions
{
    public static class CourseExtension
    {
        public static List<Course> ConvertToModel(this List<Institute.BLL.Models.CourseModel> courseModel)
        {
            var courses = courseModel.Select(item => new Course()
            {
                Title = item.Title,
                Credits = item.Credits,
                CourseID = item.CourseID,
            }).ToList();

            return courses;
        }
    }
}
