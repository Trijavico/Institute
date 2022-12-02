using Institute.BLL.Core;
using Institute.DAL.Interfaces;

namespace Institute.BLL.Validations
{
    public class ValidationsStudent
    {
        public static ServiceResult IsValidStudent(DtoStudentBase studentBase, IStudentRepository studentRepository)
        {
            ServiceResult result = new ServiceResult();

            var resutlIsValid = ValidationsPerson.IsValidPerson(studentBase);


            if (resutlIsValid.Success)
            {
                if (studentBase.EnrollmentDate.HasValue)
                {
                
                    if (studentRepository.Exists(st =>
                        st.FirstName == studentBase.FirstName
                        && st.LastName == studentBase.LastName
                        && st.EnrollmentDate == studentBase.EnrollmentDate))
                    {
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Este Estudiante ya se encuentra registrado.";
                        return result;
                    }

                }
                else
                {
                    result.Success = false;
                    result.Message = "La fecha de inscripcion es requerida.";
                    return result;
                }
            }
            else
            {
                result.Success = resutlIsValid.Success;
                result.Message = resutlIsValid.Message;
                return result;
            }

            return result;
        }
    }
}