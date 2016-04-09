using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using BASMockSite.Models;
using Microsoft.AspNet.Http;
using System;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace BASMockSite.Controllers
{
    public class SchoolsController : Controller
    {
        private ApplicationDbContext _context;
        private Utilities.CollegeRepository collegeRepo = null;
        private UserManager<ApplicationUser> _userManager;

        public SchoolsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            collegeRepo = new Utilities.CollegeRepository(context);
        }

        // GET: Schools
        public IActionResult Index()
        {
            return View(collegeRepo.GetAllInclude(s => s.Degrees));
        }

        // GET: Schools/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            College school = null;
            if (id != null)
                school = collegeRepo.Get((int)id);
            if (school == null)
            {
                return HttpNotFound();
            }

            return View(school);
        }

        // GET: Schools/Create
        [Authorize(Roles = "BASAdmin")]
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

                collegeRepo.Insert(school);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(school);
        }

        // GET: Schools/Edit/5
        // Only BAS Administrators can edit a college. To ensure this is the only case, this method
        // first checks to see if the currently logged on user can be found in the database.
        // If we find the user, we want to check their BASManagerID property. If that property has a value (it's nullable)
        // we'll get the college by it's ID and all of the associated program managers.
        // From the college's program managers, we'll find the one that matches the currently logged in user, and
        // we'll check to see if that user has a matching BASManagerID associated w/ them.
        // Once we've proven that the user is a BAS Manager with a corresponding BASManagerID for the college,
        // Well provide a view with the information for that college which can be edited.
        [Authorize(Roles = "BASAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
            if (id != null)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                College college = collegeRepo.GetInclude((int)id, c => c.ProgramManagers);
                ProgramManager progManager = college.ProgramManagers.Where(pm => pm.Email == user.Email).SingleOrDefault();
                

                if (IsUserCollegesProgramManager(user, college, progManager))
                {
                    return View(college);
                }
                else
                {
                    return RedirectToAction("Unauthorized", "Home", null);
                }

            }

            // If we get here, a program manager was found for the college in question,
            // however they do not have a matching BASManagerID and thus, they are not authorized to edit this page.
            return RedirectToAction("Unauthorized", "Home", null);
        }

        // POST: Schools/Edit/5
        [HttpPost]
        [Authorize(Roles = "BASAdmin")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(College school, IFormFile logo)
        {
            if (ModelState.IsValid)
            {
                collegeRepo.Update(school, logo);                
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(school);
        }

        // GET: Schools/Delete/5
        [ActionName("Delete")]
        [Authorize(Roles = "BASAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            College college = collegeRepo.GetInclude((int)id, c => c.ProgramManagers);
            ProgramManager progManager = college.ProgramManagers.Where(pm => pm.Email == user.Email).SingleOrDefault();
            
            if (IsUserCollegesProgramManager(user, college, progManager))
            {
                return View(college);
            }
            else
            {
                return RedirectToAction("Unauthorized", "Home", null);
            }
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "BASAdmin")]
        public IActionResult DeleteConfirmed(int id)
        {
            College school = _context.Colleges.Single(m => m.CollegeID == id);
            _context.Colleges.Remove(school);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Determines if the user is associated with the college's program manager in the database.
        /// </summary>
        /// <param name="user">The current ApplicationUser.</param>
        /// <param name="college">The college with a potentially matching program manager.</param>
        /// <param name="pm">The ProgramManager we're trying to match to the college</param>
        /// <returns>Returns true if the User is the ProgramManager for the College. Returns false if not. Returns false if any of the arguments are null, or if the user does not have a BASManagerID</returns>
        private bool IsUserCollegesProgramManager(ApplicationUser user, College college, ProgramManager pm)
        {
            // Potentially refactor to throw an error instead of just returning false
            if (user == null || college == null || pm == null)
                return false;

            int? BASManagerID = user.BASManagerID;
            if (!BASManagerID.HasValue)
                return false;

            if (pm.ManagerID == (int)BASManagerID && college.CollegeID == pm.CollegeID)
            {
                return true;
            }
            
            return false;
        }

        public FileContentResult GetSchoolLogo(int schoolID)
        {
            College school = _context.Colleges.Where(s => s.CollegeID == schoolID).SingleOrDefault();
            if (school != null && school.Logo != null)
            {
                return new FileContentResult(school.Logo, "image/jpeg");
            }
            return null;
        }
    }
}
