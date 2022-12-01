using Institute.DAL.Context;
using Institute.DAL.Core;
using Institute.DAL.Entities;
using Institute.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace Institute.DAL.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly InstituteContext context;
        private readonly ILogger<StudentRepository> logger;

        public StudentRepository(InstituteContext dbContext, ILogger<StudentRepository> logger)
            : base(dbContext)
        {
            this.context = dbContext;
            this.logger = logger;
        }

        public override void Save(Student student)
        {
            base.Save(student);
            context.SaveChanges();
        }

        public override void Update(Student entity)
        {
            try
            {
                Student studentToUpdate = base.GetEntity(entity.Id);

                studentToUpdate.FirstName = entity.FirstName;
                studentToUpdate.LastName = entity.LastName;
                studentToUpdate.EnrollmentDate = entity.EnrollmentDate;
                studentToUpdate.Id = entity.Id;

                this.context.Students.Update(studentToUpdate);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error actualizando el estudiante {ex.Message}", ex.ToString());
                throw;
            }
        }
    }
}