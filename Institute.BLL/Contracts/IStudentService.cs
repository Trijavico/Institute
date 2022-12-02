using Institute.BLL.Core;
using Institute.BLL.Dto.Student;
using Institute.BLL.Responses;

namespace Institute.BLL.Contracts
{
    public interface IStudentService : IBaseService
    {
        StudentSaveResponse SaveStudent(StudentSaveDto studentSaveDto);
        StudentUpdateResponse UpdateStudent(StudentUpdateDto studentSaveDto);
        ServiceResult RemoveStudent(StudentRemoveDto studentSaveDto);
        ServiceResult GetStudentsGrades();
    }

}