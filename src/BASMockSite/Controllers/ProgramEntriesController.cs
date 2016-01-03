using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using BASMockSite.Models;

namespace BASMockSite.Controllers
{
    public class ProgramEntriesController : Controller
    {
        private ApplicationDbContext _context;

        public ProgramEntriesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ProgramEntries
        public IActionResult Index()
        {
            var applicationDbContext = _context.ProgramEntries.Include(p => p.Degree);
            return View(applicationDbContext.ToList());
        }

        // GET: ProgramEntries/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProgramEntry programEntry = _context.ProgramEntries.Single(m => m.EntryID == id);
            if (programEntry == null)
            {
                return HttpNotFound();
            }

            return View(programEntry);
        }

        // GET: ProgramEntries/Create
        public IActionResult Create()
        {
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "Degrees");
            return View();
        }

        // POST: ProgramEntries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProgramEntry programEntry)
        {
            if (ModelState.IsValid)
            {
                _context.ProgramEntries.Add(programEntry);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "Degrees", programEntry.DegreeID);
            return View(programEntry);
        }

        // GET: ProgramEntries/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProgramEntry programEntry = _context.ProgramEntries.Single(m => m.EntryID == id);
            if (programEntry == null)
            {
                return HttpNotFound();
            }
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "Degrees", programEntry.DegreeID);
            return View(programEntry);
        }

        // POST: ProgramEntries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProgramEntry programEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Update(programEntry);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "Degrees", programEntry.DegreeID);
            return View(programEntry);
        }

        // GET: ProgramEntries/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProgramEntry programEntry = _context.ProgramEntries.Single(m => m.EntryID == id);
            if (programEntry == null)
            {
                return HttpNotFound();
            }

            return View(programEntry);
        }

        // POST: ProgramEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ProgramEntry programEntry = _context.ProgramEntries.Single(m => m.EntryID == id);
            _context.ProgramEntries.Remove(programEntry);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
