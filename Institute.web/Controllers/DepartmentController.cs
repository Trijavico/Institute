using Institute.BLL.Contracts;
using Institute.web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Institute.web.Models;
using Institute.BLL.Dto.Professor;
using Institute.BLL.Models;
using Institute.BLL.Dto.Department;

namespace Institute.web.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            this._service = service;
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            var departments = ((List<Institute.BLL.Models.DepartmentModel>)_service.GetAll().Data).ConvertToModel();

            return View(departments);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var dpto = (BLL.Models.DepartmentModel)_service.GetById(id).Data;

            Department dptoModel = new Department()
            {
                Id = dpto.Id,
                Name = dpto.Name,
                Budget = dpto.Budget,
                StartDate = dpto.StartDate,
                Administrator = dpto.Administrator,
            };

            return View(dptoModel);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department dptoModel)
        {
            try
            {
                DepartmentSaveDto departmentSaveDto = new DepartmentSaveDto()
                {
                    DepartmentID = dptoModel.Id,
                    Name = dptoModel.Name,
                    Budget = dptoModel.Budget,
                    Administrator = dptoModel.Administrator,
                    UserId = 1,
                    AuditDate = DateTime.Now
                };

                var resul = _service.SaveDepartment(departmentSaveDto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var dpto = (BLL.Models.DepartmentModel)_service.GetById(id).Data;

            Department dptoModel = new Department()
            {
                Id = dpto.Id,
                Name = dpto.Name,
                Budget = dpto.Budget,
                StartDate = dpto.StartDate,
                Administrator = dpto.Administrator
            };

            return View(dptoModel);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department dptoModel)
        {
            try
            {

                DepartmentUpdateDto professorUpdate = new BLL.Dto.Department.DepartmentUpdateDto()
                {
                    DepartmentID = dptoModel.Id,
                    Name = dptoModel.Name,
                    Budget = dptoModel.Budget,
                    StartDate = dptoModel.StartDate,
                    Administrator = dptoModel.Administrator,
                    UserId = 1,
                    AuditDate = DateTime.Now
                };

                _service.UpdateDepartment(professorUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var dpto = (BLL.Models.DepartmentModel)_service.GetById(id).Data;

            Department dptoModel = new Department()
            {
                Id = dpto.Id,
                Name = dpto.Name,
                Budget = dpto.Budget,
                StartDate = dpto.StartDate,
                Administrator = dpto.Administrator
            };

            return View(dptoModel);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Department dptoModel)
        {
            try
            {
                DepartmentRemoveDto departmentRemove = new BLL.Dto.Department.DepartmentRemoveDto()
                {
                    DepartmentID = dptoModel.Id,
                };

                _service.RemoveDepartment(departmentRemove);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
