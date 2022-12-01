using Institute.DAL.Context;
using Institute.DAL.Core;
using Institute.DAL.Entities;
using Institute.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Institute.DAL.Repositories
{
    public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
    {
        private readonly InstituteContext context;
        private readonly ILogger<ProfessorRepository> logger;

        public ProfessorRepository(InstituteContext dbContext, ILogger<ProfessorRepository> logger) 
            : base(dbContext)
        {
            this.context = dbContext;
            this.logger = logger;
        }

        public override void Save(Professor professor)
        {
            base.Save(professor);
            context.SaveChanges();
        }

        public override void Update(Professor entity)
        {
            try
            {
                Professor professorToUpdate = base.GetEntity(entity.Id);

                professorToUpdate.FirstName = entity.FirstName;
                professorToUpdate.LastName = entity.LastName;
                professorToUpdate.HireDate = entity.HireDate;
                professorToUpdate.Id = entity.Id;

                this.context.Instructors.Update(professorToUpdate);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error updating the professor {ex.Message}", ex.ToString());
                throw ex;
            }
        }


    }
}
