using Institute.BLL.Core;
using Institute.BLL.Dto.Course;
using Institute.BLL.Dto.Department;
using Institute.BLL.Responses;

namespace Institute.BLL.Contracts
{
    public interface ICourseService : IBaseService
    {
        CourseSaveResponse SaveCourse(CourseSaveDto courseSaveDto);
        CourseUpdateResponse UpdateCourse(CourseUpdateDto courseUpdateDto);
        ServiceResult RemoveCourse(CourseRemoveDto courseRemoveDto);

        
    }
}
