using Institute.BLL.Dto;
using Institute.DAL.Entities;

namespace Institute.BLL.Extentions
{
    public static class StudentExtention
    {
        public static Student FromDtoSaveToEntity(this StudentSaveDto studentSave)
        {
            return new Student()
            {
                Id = studentSave.Id,
                FirstName = studentSave.FirstName,
                LastName = studentSave.LastName,
                EnrollmentDate = studentSave.EnrollmentDate
            };
        }

        public static Student FromDtoUpdateToEntity(this StudentUpdateDto student)
        {
            return new Student()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                EnrollmentDate = student.EnrollmentDate
            };
        }
    }
}