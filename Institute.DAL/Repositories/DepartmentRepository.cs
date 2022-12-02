using Institute.DAL.Context;
using Institute.DAL.Core;
using Institute.DAL.Entities;
using Institute.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Institute.DAL.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly InstituteContext context;
        private readonly ILogger<DepartmentRepository> logger;

        public DepartmentRepository(InstituteContext dbContext, ILogger<DepartmentRepository> logger)
            : base(dbContext)
        {
            this.context = dbContext;
            this.logger = logger;
        }


        public override void Save(Department department)
        {
            base.Save(department);
            context.SaveChanges();
        }

        public override void Update(Department entity)
        {
            try
            {
                Department deparmentToUpdate = base.GetEntity(entity.DepartmentID);

                deparmentToUpdate.Name = entity.Name;
                deparmentToUpdate.Budget = entity.Budget;
                deparmentToUpdate.StartDate = entity.StartDate;
                deparmentToUpdate.Administrator = entity.Administrator;

                this.context.Department.Update(deparmentToUpdate);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error updating the department {ex.Message}", ex.ToString());
                throw ex;
            }
        }

    }
}
