using Institute.BLL.Core;
using Institute.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.BLL.Validations
{
    public class ValidationsProfessor
    {
        public static ServiceResult IsValidProfessor(ProfessorDtoBase professorBase, IProfessorRepository professorRepository)
        {
            ServiceResult result = new ServiceResult();

            var resutlIsValid = ValidationsPerson.IsValidPerson(professorBase);


            if (resutlIsValid.Success)
            {
                if (professorBase.HireDate.HasValue)
                {

                    if (professorRepository.Exists(st =>
                        st.FirstName == professorBase.FirstName
                        && st.LastName == professorBase.LastName
                        && st.HireDate == professorBase.HireDate))
                    {
                        result.Success = false;
                        result.Message = "This professor already exists.";
                        return result;
                    }

                }
                else
                {
                    result.Success = false;
                    result.Message = "The hire date is required.";
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
