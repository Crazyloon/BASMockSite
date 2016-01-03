using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using BASMockSite.Models;
using Microsoft.AspNet.Http;
using System;
using Microsoft.AspNet.Authorization;

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
            return View(_context.Colleges.Include(s => s.Degrees).ToList());
        }

        // GET: Schools/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            College school = _context.Colleges.Single(m => m.CollegeID == id);
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
        public IActionResult Create(College school, IFormFile logo)
        {
            if (ModelState.IsValid)
            {
                if (logo != null)
                {
                    byte[] imgBytes = new byte[logo.Length];
                    logo.OpenReadStream().Read(imgBytes, 0, (int)logo.Length);
                    school.Logo = imgBytes;
                }                

                _context.Colleges.Add(school);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(school);
        }

        // GET: Schools/Edit/5
        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            College school = _context.Colleges.Single(m => m.CollegeID == id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: Schools/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(College school, IFormFile logo)
        {
            if (ModelState.IsValid)
            {
                if (logo != null)
                {
                    byte[] imgBytes = new byte[logo.Length];
                    logo.OpenReadStream().Read(imgBytes, 0, (int)logo.Length);
                    school.Logo = imgBytes;

                    _context.Update(school);
                }
                else
                {
                    _context.Update(school).Property(s => s.Logo).IsModified = false;
                }

                
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

            College school = _context.Colleges.Single(m => m.CollegeID == id);
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
            College school = _context.Colleges.Single(m => m.CollegeID == id);
            _context.Colleges.Remove(school);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileContentResult GetSchoolLogo(int schoolID)
        {
            College school = _context.Colleges.Where(s => s.CollegeID == schoolID).SingleOrDefault();
            if (school.Logo != null)
            {
                return new FileContentResult(school.Logo, "image/jpeg");
            }
            return null;
        }
    }
}
