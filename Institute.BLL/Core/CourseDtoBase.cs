
namespace Institute.BLL.Core
{
    public class CourseDtoBase : DtoAudit
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
    }
}
