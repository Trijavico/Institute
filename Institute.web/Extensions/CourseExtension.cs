using Institute.web.Models;

namespace Institute.web.Extensions
{
    public static class CourseExtension
    {
        public static List<Course> ConvertToModel(this List<Institute.BLL.Models.CourseModel> courseModel)
        {
            var courses = courseModel.Select(item => new Course()
            {
                Id = item.CourseId,
                Title = item.Title,
                Credits = item.Credits
            }).ToList();

            return courses;
        }
    }
}
