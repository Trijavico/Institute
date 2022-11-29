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
    }
}
