
using Microsoft.EntityFrameworkCore;
using Institute.DAL.Entities;

namespace Institute.DAL.Context
{
    public class InstituteContext : DbContext
    {
        public InstituteContext()
        {

        }

        public InstituteContext(DbContextOptions<InstituteContext> options)
            : base(options)
        {

        }

        public DbSet<Professor> Instructors { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }
    }
}
