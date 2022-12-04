using Institute.BLL.Dto.Course;
using Institute.BLL.Responses;

namespace Institute.BLL.Core
{
    public interface IBaseService
    {
        ServiceResult GetAll();
        ServiceResult GetById(int Id);
    }
}
