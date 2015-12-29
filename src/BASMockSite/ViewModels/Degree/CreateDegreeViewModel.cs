using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BASMockSite.Models;
using Microsoft.AspNet.Mvc.Rendering;

namespace BASMockSite.ViewModels.Degree
{
    public class CreateDegreeViewModel
    {
        [Key]
        public int DegreeID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        // Like 90 Credits, 6 quarters
        [Required]
        public string ProgramDuration { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string ProgramURL { get; set; }

        public SelectList Schools { get; set; }
        public SelectList ProgramManagers { get; set; }
        public MultiSelectList CourseModels { get; set; }

        //public IEnumerable<SelectListItem> Schools { get; set; }
        //public IEnumerable<SelectListItem> ProgramManagers { get; set; }
        //public IEnumerable<MultiSelectList> CourseModels { get; set; }
    }
}
