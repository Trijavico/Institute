using Institute.BLL.Dto.Department;
using Institute.BLL.Dto.Professor;
using Institute.DAL.Entities;

namespace Institute.BLL.Extensions
{
    public static class DepartmentExtension
    {
        public static Department FromDtoSaveToEntity(this DepartmentSaveDto dptoSave)
        {
            return new Department()
            {
                Name = dptoSave.Name,
                Budget = dptoSave.Budget,
                StartDate = (DateTime)dptoSave.StartDate,
                Administrator = dptoSave.Administrator,
                CreationDate = dptoSave.AuditDate,
                CreationUser = dptoSave.UserId
            };
        }

        public static Department FromDtoUpdateToEntity(this DepartmentUpdateDto dptoUpdate)
        {
            return new Department()
            {
                DepartmentID = dptoUpdate.DepartmentID,
                Name = dptoUpdate.Name,
                Budget = dptoUpdate.Budget,
                StartDate = (DateTime)dptoUpdate.StartDate,
                Administrator = dptoUpdate.Administrator,
                ModifyDate = dptoUpdate.AuditDate,
                UserMod = dptoUpdate.UserId
            };
        }
    }
}
