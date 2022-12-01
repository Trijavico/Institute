
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
                result.Message = "The name is required.";
                return result;
            }

            if (string.IsNullOrEmpty(person.LastName))
            {
                result.Success = false;
                result.Message = "The lastname is required.";
                return result;
            }

            if (person.FirstName.Length > 50)
            {
                result.Success = false;
                result.Message = "The name length is invalid";
                return result;
            }

            if (person.LastName.Length > 50)
            {
                result.Success = false;
                result.Message = "The lastname length is invalid.";
                return result;
            }

            return result;
        }
    }
}
