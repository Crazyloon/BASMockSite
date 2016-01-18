using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using BASMockSite.Models;

namespace BASMockSite.Controllers
{
    public class ProgramManagersController : Controller
    {
        private ApplicationDbContext _context;

        public ProgramManagersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ProgramManagers
        public IActionResult Index()
        {
            var applicationDbContext = _context.ProgramManagers.Include(p => p.College);
            return View(applicationDbContext.ToList());
        }

        // GET: ProgramManagers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProgramManager programManager = _context.ProgramManagers.Single(m => m.ManagerID == id);
            if (programManager == null)
            {
                return HttpNotFound();
            }

            return View(programManager);
        }

        // GET: ProgramManagers/Create
        public IActionResult Create()
        {
            ViewData["CollegeID"] = new SelectList(_context.Colleges, "CollegeID", "College");
            return View();
        }

        // POST: ProgramManagers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProgramManager programManager)
        {
            if (ModelState.IsValid)
            {
                _context.ProgramManagers.Add(programManager);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CollegeID"] = new SelectList(_context.Colleges, "CollegeID", "College", programManager.CollegeID);
            return View(programManager);
        }

        // GET: ProgramManagers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProgramManager programManager = _context.ProgramManagers.Single(m => m.ManagerID == id);
            if (programManager == null)
            {
                return HttpNotFound();
            }
            ViewData["CollegeID"] = new SelectList(_context.Colleges, "CollegeID", "College", programManager.CollegeID);
            return View(programManager);
        }

        // POST: ProgramManagers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProgramManager programManager)
        {
            if (ModelState.IsValid)
            {
                _context.Update(programManager);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CollegeID"] = new SelectList(_context.Colleges, "CollegeID", "College", programManager.CollegeID);
            return View(programManager);
        }

        // GET: ProgramManagers/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProgramManager programManager = _context.ProgramManagers.Single(m => m.ManagerID == id);
            if (programManager == null)
            {
                return HttpNotFound();
            }

            return View(programManager);
        }

        // POST: ProgramManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ProgramManager programManager = _context.ProgramManagers.Single(m => m.ManagerID == id);
            _context.ProgramManagers.Remove(programManager);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
