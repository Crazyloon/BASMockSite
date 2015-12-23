using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using BASMockSite.Models;
using System.Collections.Generic;


namespace BASMockSite.Controllers
{
    public class DegreesController : Controller
    {
        private ApplicationDbContext _context;

        public DegreesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Degrees
        public IActionResult Index()
        {
            var degrees = new BASMockSite.ViewModels.Degree.DegreesListViewModel();

            degrees.Degrees = _context.Degree.ToList();
            degrees.ProgramEntrys = _context.ProgramEntry.ToList();
            degrees.ProgramManagers = _context.ProgramManager.ToList();
            degrees.CourseModels = _context.CourseModel.ToList();
            degrees.Schools= _context.School.ToList();
            

            return View(degrees);
        }

        // GET: Degrees/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Degree degree = _context.Degree.Single(m => m.DegreeID == id);
            if (degree == null)
            {
                return HttpNotFound();
            }

            return View(degree);
        }

        // GET: Degrees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Degrees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Degree degree)
        {
            if (ModelState.IsValid)
            {
                _context.Degree.Add(degree);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(degree);
        }

        // GET: Degrees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Degree degree = _context.Degree.Single(m => m.DegreeID == id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // POST: Degrees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Degree degree)
        {
            if (ModelState.IsValid)
            {
                _context.Update(degree);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(degree);
        }

        // GET: Degrees/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Degree degree = _context.Degree.Single(m => m.DegreeID == id);
            if (degree == null)
            {
                return HttpNotFound();
            }

            return View(degree);
        }

        // POST: Degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Degree degree = _context.Degree.Single(m => m.DegreeID == id);
            _context.Degree.Remove(degree);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        //public ActionResult _DegreePartialOrig()
        //{
        //    List<Degree> degrees;
        //    degrees = _context.Degree.Include(d => d.CourseModels.Select(cm => cm.EntryStructure.Select(es => es.EntrySummary))).ToList();
        //    ViewBag.DegreeCourseModels = _context.CourseModel.ToList();
        //    ViewBag.DegreeProgramEntry = _context.ProgramEntry.ToList();

        //    return PartialView("_DegreePartial", degrees);
        //}

        public ActionResult _DegreePartial()
        {
            var degrees = new BASMockSite.ViewModels.Degree.DegreesListViewModel();
            for (int i = 0; i < _context.Degree.Count(); i++)
            {
                degrees.Degrees = _context.Degree.ToList();
                degrees.ProgramEntrys = _context.ProgramEntry.ToList();
                degrees.ProgramManagers = _context.ProgramManager.ToList();
                degrees.CourseModels = _context.CourseModel.ToList();
            }

            return PartialView("_DegreePartial", degrees);
        }
    }
}
