using Microsoft.AspNetCore.Mvc;
using Institute.BLL.Contracts;
using Institute.Web.Extentions;
using Institute.BLL.Models;
using Institute.DAL.Entities;
using Institute.web.Models;
using Institute.BLL.Dto.Student;

namespace Institute.web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var students = ((List<StudentModel>)_studentService.GetAll().Data)
                                                                              .ConvertStudentModelToModel();

            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var studentModel = ((StudentModel)this._studentService.GetById(id).Data)
                                              .ConvertFromStudentModelToStudent();

            return View(studentModel);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Student studentModel)
        {
            try
            {
                StudentSaveDto saveStudnetDto = new Institute.BLL.Dto.Student.StudentSaveDto()
                {
                    FirstName = studentModel.FirstName,
                    LastName = studentModel.LastName,
                    EnrollmentDate = studentModel.EnrollmentDate
                    
                };

                _studentService.SaveStudent(saveStudnetDto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {

            var student = (Institute.BLL.Models.StudentModel)_studentService.GetById(id).Data;

            Models.Student Modelstudent = new Institute.web.Models.Student()
            {
                PersonID = student.Id,
                EnrollmentDate = student.EnrollmentDate,
                FirstName = student.FirstName,
                LastName = student.LastName
            };

            return View(Modelstudent);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Student studentModel)
        {
            try
            {
                var myModel = studentModel;

                BLL.Dto.StudentUpdateDto studentUpdate = new BLL.Dto.StudentUpdateDto()
                {
                    Id = studentModel.Id,
                    FirstName = studentModel.FirstName,
                    LastName = studentModel.LastName,
                    EnrollmentDate = studentModel.EnrollmentDate.Value   
                    
                };

                _studentService.UpdateStudent(studentUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}