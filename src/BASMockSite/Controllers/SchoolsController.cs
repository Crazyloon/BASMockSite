using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using BASMockSite.Models;

namespace BASMockSite.Controllers
{
    public class SchoolsController : Controller
    {
        private ApplicationDbContext _context;

        public SchoolsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Schools
        public IActionResult Index()
        {
            return View(_context.School.ToList());
        }

        // GET: Schools/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            School school = _context.School.Single(m => m.SchoolID == id);
            if (school == null)
            {
                return HttpNotFound();
            }

            return View(school);
        }

        // GET: Schools/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schools/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(School school)
        {
            if (ModelState.IsValid)
            {
                _context.School.Add(school);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(school);
        }

        // GET: Schools/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            School school = _context.School.Single(m => m.SchoolID == id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: Schools/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(School school)
        {
            if (ModelState.IsValid)
            {
                _context.Update(school);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(school);
        }

        // GET: Schools/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            School school = _context.School.Single(m => m.SchoolID == id);
            if (school == null)
            {
                return HttpNotFound();
            }

            return View(school);
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            School school = _context.School.Single(m => m.SchoolID == id);
            _context.School.Remove(school);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
