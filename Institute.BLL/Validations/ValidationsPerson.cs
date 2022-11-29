
using Institute.BLL.Core;

namespace Institute.BLL.Validations
{
    public class ValidationsPerson
    {
        public static ServiceResult IsValidPerson(PersonDto person)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(person.FirstName))
            {
                result.Success = false;
                result.Message = "El nombre es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(person.LastName))
            {
                result.Success = false;
                result.Message = "El apellido es requerido.";
                return result;
            }

            if (person.FirstName.Length > 50)
            {
                result.Success = false;
                result.Message = "La longitud del nombre es inválida.";
                return result;
            }

            if (person.LastName.Length > 50)
            {
                result.Success = false;
                result.Message = "La longitud del apellido es inválida.";
                return result;
            }

            return result;
        }
    }
}
