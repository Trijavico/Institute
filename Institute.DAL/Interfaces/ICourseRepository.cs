
using Institute.DAL.Core;
using Institute.DAL.Entities;

namespace Institute.DAL.Interfaces
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        void Save(Department courseToAdd);
    }
}
