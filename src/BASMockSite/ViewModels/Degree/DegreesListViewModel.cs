using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.ViewModels.Degree
{
    public class DegreesListViewModel
    {
        public IEnumerable<BASMockSite.Models.Degree> Degrees { get; set; }
        public IEnumerable<BASMockSite.Models.ProgramEntry> ProgramEntrys { get; set; }
        public IEnumerable<BASMockSite.Models.ProgramManager> ProgramManagers { get; set; }
        public IEnumerable<BASMockSite.Models.CourseModel> CourseModels { get; set; }
        public IEnumerable<BASMockSite.Models.School> Schools { get; set; }

    }
}
