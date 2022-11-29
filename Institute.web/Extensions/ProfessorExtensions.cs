using Institute.web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Institute.web.Extensions
{
    public static class ProfessorExtensions
    {
        public static List<Professor> ConvertToModel(this List<Institute.BLL.Models.ProfessorModel> professorModels)
        {
            var myProfessors = professorModels.Select(item => new Professor()
            {
                LastName = item.LastName,
                FirstName = item.FirstName,
                Id = item.Id,
                HireDate = item.HireDate
            }).ToList();

            return myProfessors;

        }
    }
}
