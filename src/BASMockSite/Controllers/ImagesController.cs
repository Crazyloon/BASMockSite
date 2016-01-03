using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using BASMockSite.Models;
using Microsoft.AspNet.Hosting;
using System.Collections.Generic;
using Microsoft.AspNet.Http;
using System.IO;
using Microsoft.Net.Http.Headers;

namespace BASMockSite.Controllers
{
    public class ImagesController : Controller
    {
        private ApplicationDbContext _context;
        private IHostingEnvironment _environment;

        public ImagesController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Images
        public IActionResult Index()
        {
            var applicationDbContext = _context.Images.Include(i => i.College);
            return View(applicationDbContext.ToList());
        }

        // GET: Images/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Image image = _context.Images.Single(m => m.ImageID == id);
            if (image == null)
            {
                return HttpNotFound();
            }

            return View(image);
        }

        // GET: Images/Create
        public IActionResult Create()
        {
            ViewBag.CollegeID = new SelectList(_context.Colleges, "CollegeID", "Name");
            return View();
        }

        // POST: Images/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Image image, ICollection<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                var uploads = Path.Combine(_environment.WebRootPath, "uploads\\images");
                foreach (var img in files)
                {
                    if (img.Length > 0)
                    {
                        var imgName = ContentDispositionHeaderValue.Parse(img.ContentDisposition).FileName.Trim('"');
                        string imgPath = Path.Combine(uploads, imgName);
                        img.SaveAs(imgPath);
                        Image newImage = new Image
                        {
                            ImageURL = imgPath,
                            CollegeID = image.CollegeID
                        };
                        _context.Images.Add(newImage);
                    }
                }
                
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CollegeID"] = new SelectList(_context.Colleges, "CollegeID", "Name", image.CollegeID);
            return View(image);
        }

        // GET: Images/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Image image = _context.Images.Single(m => m.ImageID == id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewData["CollegeID"] = new SelectList(_context.Colleges, "CollegeID", "College", image.CollegeID);
            return View(image);
        }

        // POST: Images/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Image image)
        {
            if (ModelState.IsValid)
            {
                _context.Update(image);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CollegeID"] = new SelectList(_context.Colleges, "CollegeID", "College", image.CollegeID);
            return View(image);
        }

        // GET: Images/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Image image = _context.Images.Single(m => m.ImageID == id);
            if (image == null)
            {
                return HttpNotFound();
            }

            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Image image = _context.Images.Single(m => m.ImageID == id);
            _context.Images.Remove(image);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
