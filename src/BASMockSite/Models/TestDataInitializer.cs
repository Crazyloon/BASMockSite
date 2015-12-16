using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace BASMockSite.Models
{
    public class TestDataInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.School.Any())
            {
                var rtc = context.School.Add(
                    new School { Name ="Renton Technical College", County = "King", Tuition = 7200.00m, EntryDate = DateTime.Today}).Entity;

                var bcc = context.School.Add(
                    new School { Name = "Bellevue Community College", County = "King", Tuition = 7200.00m, EntryDate = DateTime.Today }).Entity;

                var bates = context.School.Add(
                    new School { Name = "Bates Community College", County = "King", Tuition = 7200.00m, EntryDate = DateTime.Today }).Entity;

                var pscc = context.School.Add(
                    new School { Name = "Puget Sound Community College", County = "King", Tuition = 7200.00m, EntryDate = DateTime.Today }).Entity;

                context.SaveChanges();
            }
        }

    }
}
