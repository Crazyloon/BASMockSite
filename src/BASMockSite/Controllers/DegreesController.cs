using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using BASMockSite.Models;

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
            return View(_context.Degree.ToList());
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
    }
}
