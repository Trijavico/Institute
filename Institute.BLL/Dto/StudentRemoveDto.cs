using System;

namespace Institute.BLL.Dto
{
    public class StudentRemoveDto
    {
        public int Id { get; set; }
        public int UserDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}