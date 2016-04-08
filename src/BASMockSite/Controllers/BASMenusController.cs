using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using BASMockSite.Models;
using BASMockSite.ViewModels.BASManagers;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;

namespace BASMockSite.Controllers
{
    [Authorize(Roles = "BASAdmin")]
    public class BASMenusController : Controller
    {
        private ApplicationDbContext _context;

        public BASMenusController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: BASMenus
        public IActionResult Index()
        {
            // Get the current user and find out if they have a BASManagerID
            // They should given they're unable to get here if they're not a BASAdmin
            // Once we've got their BASManagerID we compare it to the ProgramManager table
            // If we can find the corresponding ID in that table, we'll display information for this manager.
            BASMenu menu = null;
            string userName = User.GetUserName();
            var user = _context.Users.Where(u => u.UserName == userName).FirstOrDefault();
            if (user.BASManagerID != null)
            {
                int BASManagerID = (int)user.BASManagerID;
                ProgramManager pm = _context.ProgramManagers.Where(m => m.ManagerID == BASManagerID).SingleOrDefault();
                List<Degree> dl = _context.Degrees.ToList();
                menu = new BASMenu
                {
                    ManagerID = pm.ManagerID,
                    Manager = pm,
                    College = _context.Colleges.Where(c => c.CollegeID == pm.CollegeID).SingleOrDefault(),
                    Degrees = dl.Where(d => d.ProgramManagerID == pm.ManagerID).ToList(),
                };

                return View(menu);
            }
            // Instead of returning the user to a blank Menu page, redirect them to an error page.
            return View(menu);            
        }        
    }
}
