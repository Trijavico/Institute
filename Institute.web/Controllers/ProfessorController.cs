using Institute.BLL.Contracts;
using Institute.web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Institute.web.Models;
using Institute.BLL.Dto.Professor;

namespace Institute.web.Controllers
{
    public class ProfessorController : Controller
    {

        private readonly IProfessorService _service;

        public ProfessorController(IProfessorService service)
        {
            this._service = service;
        }


        // GET: ProfessorController
        public ActionResult Index()
        {
            var professors = ((List<Institute.BLL.Models.ProfessorModel>)_service.GetAll().Data).ConvertToModel();

            return View(professors);
        }

        // GET: ProfessorController/Details/5
        public ActionResult Details(int id)
        {

            var pf = (BLL.Models.ProfessorModel)_service.GetById(id).Data;

            Professor Modelpf = new Professor()
            {
                Id = pf.Id,
                FirstName = pf.FirstName,
                LastName = pf.LastName,
                HireDate = pf.HireDate
            };

            return View(Modelpf);
        }

        // GET: ProfessorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfessorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Professor professorModel)
        {
            try
            {

                bool isValidDate = DateTime.TryParse(professorModel.HireDate.Value.ToString(), out DateTime myDate);

                ProfessorSaveDto professorSaveDto = new BLL.Dto.Professor.ProfessorSaveDto()
                {
                    HireDate = professorModel.HireDate,
                    FirstName = professorModel.FirstName,
                    LastName = professorModel.LastName
                };

                var resul = _service.SaveProfessor(professorSaveDto);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfessorController/Edit/5
        public ActionResult Edit(int id)
        {
            var pf = (BLL.Models.ProfessorModel)_service.GetById(id).Data;

            Professor Modelpf = new Professor()
            {
                Id = pf.Id,
                FirstName = pf.FirstName,
                LastName = pf.LastName,
                HireDate = pf.HireDate
            };

            return View(Modelpf);
        }

        // POST: ProfessorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Professor professorModel)
        {
            try
            {

                ProfessorUpdateDto professorUpdate = new BLL.Dto.Professor.ProfessorUpdateDto()
                {
                    ProfessorId = professorModel.Id,
                    HireDate = professorModel.HireDate,
                    FirstName = professorModel.FirstName,
                    LastName = professorModel.LastName,
                };

                _service.UpdateProfessor(professorUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

            }
}
