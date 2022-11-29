using Institute.BLL.Core;

namespace Institute.BLL.Dto
{
    public class ProfessorRemoveDto : DtoAudit
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}
