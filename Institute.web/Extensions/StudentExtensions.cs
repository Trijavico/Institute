
using Institute.BLL.Models;

namespace Institute.Web.Extentions
{
    public static class StudentExtentions
    {
        public static List<Institute.web.Models.Student> ConvertStudentModelToModel(this List<BLL.Models.StudentModel> studentModels)
        {
            var myStudents = studentModels.Select(student => new Institute.web.Models.Student()
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstName = student.FirstName,
                EnrollmentDate = student.EnrollmentDate
            }).ToList();

            return myStudents;

        }

        public static List<Institute.web.Models.Student> GetStudents(List<StudentModel> studentModels)
        {
            var myStudents = studentModels.Select(student => new Institute.web.Models.Student()
            {
                Id = student.Id,    
                LastName = student.LastName,
                FirstName = student.FirstName,
                EnrollmentDate = student.EnrollmentDate
            }).ToList();

            return myStudents;
        }

        public static web.Models.Student ConvertFromStudentModelToStudent(this StudentModel studentModel)
        {
            return new web.Models.Student()
            {
                Id = studentModel.Id,
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                EnrollmentDate = studentModel.EnrollmentDate
            };
        }
    }
}