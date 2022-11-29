using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Institute.web.Controllers
{
    public class StudentGradeController : Controller
    {
        // GET: StudentGradeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudentGradeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentGradeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentGradeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentGradeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentGradeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentGradeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentGradeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
