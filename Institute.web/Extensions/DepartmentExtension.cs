using Institute.web.Models;
using System.Data.SqlTypes;

namespace Institute.web.Extensions
{
    public static class DepartmentExtension
    {
        public static List<Department> ConvertToModel(this List<Institute.BLL.Models.DepartmentModel> departmentModel)
        {
            var departments = departmentModel.Select(item => new Department()
            {
                Id = item.Id,
                Name = item.Name,
                Budget = item.Budget,
                StartDate = item.StartDate,
                Administrator = item.Administrator
            }).ToList();

            return departments;
        }
    }
}
