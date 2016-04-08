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
            List<Degree> degrees = _context.Degrees.Include(d => d.ProgramManager).Include(d => d.College).ToList();
            List<ProgramEntry> entries = _context.ProgramEntries.Include(pe => pe.Structures).ToList();
            var dlvm = new List<BASMockSite.ViewModels.Degree.DegreesListViewModel>();

            int i = 0;
            foreach (var degree in degrees)
            {
                dlvm.Add(new ViewModels.Degree.DegreesListViewModel());

                dlvm[i].DegreeID = degree.DegreeID;
                dlvm[i].ProgramManagerID = degree.ProgramManagerID;
                dlvm[i].SchoolID = degree.CollegeID;

                dlvm[i].DegreeName = degree.Name;
                dlvm[i].AdmissionsSummary = degree.AdmissionsSummary;
                dlvm[i].DegreeDescription = degree.Description;
                dlvm[i].ProgramURL = degree.ProgramURL;
                dlvm[i].ProgramManagerName = degree.ProgramManager.Name;
                dlvm[i].ProgramManagerEmail = degree.ProgramManager.Email;
                dlvm[i].SchoolName = degree.College.Name;
                dlvm[i].ProgramEntries = entries.Where(pe => pe.DegreeID == degree.DegreeID).ToList();

                i++;
            }
            
            return View(dlvm);
        }

        // GET: Degrees/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Degree degree = _context.Degrees.Single(m => m.DegreeID == id);
            if (degree == null)
            {
                return HttpNotFound();
            }

            return View(degree);
        }

        // GET: Degrees/Create
        public IActionResult Create()
        {
            ViewBag.ManagerID = new SelectList(_context.ProgramManagers.ToList(), "ManagerID", "Name");
            ViewBag.SchoolID = new SelectList(_context.Colleges.ToList(), "CollegeID", "Name");
            return View();
        }

        // POST: Degrees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Degree degree)
        {
            if (ModelState.IsValid)
            {
                _context.Degrees.Add(degree);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManagerID = new SelectList(_context.ProgramManagers.ToList(), "ManagerID", "Name", degree.ProgramManagerID);
            ViewBag.SchoolID = new SelectList(_context.Colleges.ToList(), "CollegeID", "Name", degree.CollegeID);

            return View(degree);
        }

        // GET: Degrees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Degree degree = _context.Degrees.Single(m => m.DegreeID == id);
            //degree.College = _context.College.Where(s => s.CollegeID == degree.CollegeID).SingleOrDefault();
            if (degree == null)
            {
                return HttpNotFound();
            }

            ViewBag.ManagerID = new SelectList(_context.ProgramManagers.ToList(), "ManagerID", "Name", degree.ProgramManagerID);
            ViewBag.SchoolID = new SelectList(_context.Colleges.ToList(), "CollegeID", "Name", degree.CollegeID);

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

            ViewBag.ManagerID = new SelectList(_context.ProgramManagers.ToList(), "ManagerID", "Name", degree.ProgramManagerID);
            ViewBag.SchoolID = new SelectList(_context.Colleges.ToList(), "CollegeID", "Name", degree.CollegeID);

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

            Degree degree = _context.Degrees.Single(m => m.DegreeID == id);
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
            Degree degree = _context.Degrees.Single(m => m.DegreeID == id);
            _context.Degrees.Remove(degree);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
