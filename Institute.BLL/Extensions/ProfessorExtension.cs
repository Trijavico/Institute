
using Institute.BLL.Dto;
using Institute.DAL.Entities;

namespace Institute.BLL.Extensions
{
    public static class ProfessorExtension
    {

        public static Professor FromDtoSaveToEntity(this ProfessorSaveDto professorSave)
        {
            return new Professor()
            {
                FirstName = professorSave.FirstName,
                LastName = professorSave.LastName,
                HireDate = professorSave.HireDate
            };
        }

        public static Professor FromDtoUpdateToEntity(this ProfessorUpdateDto professor)
        {
            return new Professor()
            {
                FirstName = professor.FirstName,
                LastName = professor.LastName,
                HireDate = professor.HireDate
            };
        }
    }
}
