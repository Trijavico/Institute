using Institute.BLL.Core;
using Institute.DAL.Interfaces;

namespace Institute.BLL.Validations
{
    public class ValidationsCourse
    {
        public static ServiceResult IsValidCourse(CourseDtoBase course)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(course.Title))
            {
                result.Success = false;
                result.Message = "The name is required";
                return result;
            }

            if (course.Title.Length > 50)
            {
                result.Success = false;
                result.Message = "Invalid title lentgh.";
                return result;
            }


            return result;
        }
    }
}
