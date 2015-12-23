using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BASMockSite.ViewModels.Degree
{
    public class SingleDegreeViewModel
    {
        [Key]
        public int DegreeID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ProgramDuration { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string ProgramURL { get; set; }

        [Required]
        public string SchoolName { get; set; }

        [Required]
        public string ProgramManagerName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string ProgramManagerEmail { get; set; }
    }
}
