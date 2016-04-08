using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BASMockSite.Models;
using Microsoft.AspNet.Http;
using Microsoft.Data.Entity;
using System.Collections;
using System.Linq.Expressions;

namespace BASMockSite.Utilities
{
    public class CollegeRepository : IRepository<Models.College, int>
    {
        private ApplicationDbContext _context = null;

        public CollegeRepository()
        {
            _context = new ApplicationDbContext();
        }

        public CollegeRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public College Get(int id)
        {
            return _context.Colleges.Where(c => c.CollegeID == id).FirstOrDefault();
        }

        public College GetInclude<T>(int id, Expression<Func<College, ICollection<T>>> rule)
        {
            return _context.Colleges.Where(c => c.CollegeID == id).Include(rule).SingleOrDefault();
        }

        public IEnumerable<College> GetAll()
        {
            return _context.Colleges.ToList();
        }

        public IEnumerable<College> GetAllInclude<T>(Expression<Func<College, ICollection<T>>> rule)
        {
            return _context.Colleges.Include(rule).ToList();
        }

        public void Insert(College college)
        {
            _context.Colleges.Add(college);
        }

        public void Update(College college)
        {
            _context.Update(college);
        }

        public void Update(College college, IFormFile logo)
        {
            // Update with new Logo
            if (logo != null)
            {
                byte[] imgBytes = new byte[logo.Length];
                logo.OpenReadStream().Read(imgBytes, 0, (int)logo.Length);
                college.Logo = imgBytes;
                _context.Update(college);
            }
            // Update without a new logo
            else
            {
                // Mark the logo as unmodified so the data is not lost.
                _context.Update(college).Property(c => c.Logo).IsModified = false;
            }
            _context.SaveChanges();
        }

        public void Delete(College college)
        {
            _context.Colleges.Remove(college);
        }
    }
}
