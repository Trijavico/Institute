using Institute.BLL.Contracts;
using Institute.web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Institute.web.Models;
using Institute.BLL.Models;
using Institute.BLL.Dto.Department;
using Institute.web.Extensions;
using Institute.BLL.Dto.Course;
using Institute.DAL.Entities;
using Course = Institute.DAL.Entities.Course;

namespace Institute.web.Controllers
{
    public class CourseController : Controller
    {

        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            this._service = service;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            var courses = ((List<Institute.BLL.Models.CourseModel>)_service.GetAll().Data).ConvertToModel();

            return View(courses);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            var course
                = (BLL.Models.CourseModel)_service.GetById(id).Data;

            Course courseModel = new Course()
            {
                Title = course.Title,
                Credits = course.Credits,
                CourseID = course.CourseId,
            };

            return View(courseModel);
        }

        // GET:CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course courseModel)
        {
            try
            {
                CourseSaveDto courseSaveDto = new CourseSaveDto()
                {
                    Title = courseModel.Title,
                    Credits = courseModel.Credits,
                    CourseID = courseModel.CourseID,
                };

                var resul = _service.SaveCourse(courseSaveDto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var course = (BLL.Models.CourseModel)_service.GetById(id).Data;

            Course courseModel = new Course()
            {
                Title = course.Title,
                Credits = course.Credits,
                CourseID = course.CourseId
            };

            return View(courseModel);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course courseModel)
        {
            try
            {

                CourseUpdateDto courseUpdate = new BLL.Dto.Course.CourseUpdateDto()
                {
                Title = courseModel.Title,
                Credits = courseModel.Credits,
                CourseID = courseModel.CourseID
                };

                _service.UpdateCourse(courseUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}