using Institute.BLL.Core;
using Institute.BLL.Dto.Professor;
using Institute.BLL.Responses;

namespace Institute.BLL.Contracts
{
    public interface IProfessorService : IBaseService
    {
        ProfessorSaveResponse SaveProfessor(ProfessorSaveDto professorSaveDto);
        ProfessorUpdateResponse UpdateProfessor(ProfessorUpdateDto professorUpdateDto);
        ServiceResult RemoveProfessor(ProfessorRemoveDto professorRemoveDto);
    }
}
