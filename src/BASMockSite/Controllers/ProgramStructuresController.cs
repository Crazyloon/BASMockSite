using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using BASMockSite.Models;

namespace BASMockSite.Controllers
{
    public class ProgramStructuresController : Controller
    {
        private ApplicationDbContext _context;

        public ProgramStructuresController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ProgramStructures
        public IActionResult Index()
        {
            var applicationDbContext = _context.ProgramStructures.Include(p => p.ProgramEntry);
            return View(applicationDbContext.ToList());
        }

        // GET: ProgramStructures/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProgramStructure programStructure = _context.ProgramStructures.Single(m => m.ProgramStructureID == id);
            if (programStructure == null)
            {
                return HttpNotFound();
            }

            return View(programStructure);
        }

        // GET: ProgramStructures/Create
        public IActionResult Create()
        {
            ViewData["ProgramEntrylID"] = new SelectList(_context.ProgramEntries, "EntryID", "ProgramEntries");
            return View();
        }

        // POST: ProgramStructures/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProgramStructure programStructure)
        {
            if (ModelState.IsValid)
            {
                _context.ProgramStructures.Add(programStructure);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["ProgramEntrylID"] = new SelectList(_context.ProgramEntries, "EntryID", "ProgramEntries", programStructure.ProgramEntrylID);
            return View(programStructure);
        }

        // GET: ProgramStructures/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProgramStructure programStructure = _context.ProgramStructures.Single(m => m.ProgramStructureID == id);
            if (programStructure == null)
            {
                return HttpNotFound();
            }
            ViewData["ProgramEntrylID"] = new SelectList(_context.ProgramEntries, "EntryID", "ProgramEntries", programStructure.ProgramEntrylID);
            return View(programStructure);
        }

        // POST: ProgramStructures/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProgramStructure programStructure)
        {
            if (ModelState.IsValid)
            {
                _context.Update(programStructure);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["ProgramEntrylID"] = new SelectList(_context.ProgramEntries, "EntryID", "ProgramEntries", programStructure.ProgramEntrylID);
            return View(programStructure);
        }

        // GET: ProgramStructures/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProgramStructure programStructure = _context.ProgramStructures.Single(m => m.ProgramStructureID == id);
            if (programStructure == null)
            {
                return HttpNotFound();
            }

            return View(programStructure);
        }

        // POST: ProgramStructures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ProgramStructure programStructure = _context.ProgramStructures.Single(m => m.ProgramStructureID == id);
            _context.ProgramStructures.Remove(programStructure);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
