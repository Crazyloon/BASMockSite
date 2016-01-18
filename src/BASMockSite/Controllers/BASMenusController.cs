using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using BASMockSite.Models;
using BASMockSite.ViewModels.BASManagers;
using System.Collections.Generic;

namespace BASMockSite.Controllers
{
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
            ProgramManager pm = _context.ProgramManagers.Where(m => m.ManagerID == 1).SingleOrDefault();
            List<Degree> dl = _context.Degrees.ToList();
            BASMenu menu = new BASMenu
            {
                ManagerID = pm.ManagerID,
                Manager = pm,
                College = _context.Colleges.Where(c => c.CollegeID == pm.CollegeID).SingleOrDefault(),
                Degrees = dl.Where(d => d.ProgramManagerID == pm.ManagerID).ToList(),
            };
            return View(menu);
        }        
    }
}
