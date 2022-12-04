
using Institute.DAL.Context;
using Institute.DAL.Core;
using Institute.DAL.Entities;
using Institute.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Institute.DAL.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly InstituteContext context;
        private readonly ILogger<CourseRepository> logger;


        public CourseRepository(InstituteContext dbContext, ILogger<CourseRepository> logger)
            : base(dbContext)
        {
            this.context = dbContext;
            this.logger = logger;
        }


        public override void Save(Course course)
        {
            base.Save(course);
            context.SaveChanges();
        }

        public override void Update(Course entity)
        {
            try
            {
                Course courseToUpdate = base.GetEntity(entity.CourseID);

                courseToUpdate.Title = entity.Title;
                courseToUpdate.CourseID = entity.CourseID;
                courseToUpdate.Credits = entity.Credits;
                courseToUpdate.DepartmentID = entity.DepartmentID;

                this.context.Courses.Update(courseToUpdate);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error updating the course {ex.Message}", ex.ToString());
                throw ex;
            }
        }
    }
}
