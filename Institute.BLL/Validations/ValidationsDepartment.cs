

using Institute.BLL.Core;
using Institute.DAL.Core;
using Institute.DAL.Interfaces;

namespace Institute.BLL.Validations
{
    public class ValidationsDepartment
    {
        public static ServiceResult IsValidDepartment(DepartmentDtoBase department, IDepartmentRepository departmentRepository)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(department.Name))
            {
                result.Success = false;
                result.Message = "The name is required";
                return result;
            }


            if (result.Success)
            {
                if (department.StartDate.HasValue)
                {

                    if (departmentRepository.Exists(dpto => dpto.Name == department.Name))
                    {
                        result.Success = false;
                        result.Message = "This department already exists.";
                        return result;
                    }

                }
                else
                {
                    result.Success = false;
                    result.Message = "The start date is required";
                    return result;
                }
            }
            else
            {
                result.Success = result.Success;
                result.Message = result.Message;
                return result;
            }

            return result;
        }
    }
}
