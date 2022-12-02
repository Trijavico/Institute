
using Institute.BLL.Core;
using Institute.BLL.Dto.Department;
using Institute.BLL.Responses;

namespace Institute.BLL.Contracts
{
    public interface IDepartmentService : IBaseService
    {
        DepartmentSaveResponse SaveDepartment(DepartmentSaveDto departmentSaveDto);
        DepartmentUpdateResponse UpdateDepartment(DepartmentUpdateDto departmentUpdateDto);
        ServiceResult RemoveDepartment(DepartmentRemoveDto departmentRemoveDto);
    }
}
