using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.ViewModels.Degree
{
    public class DegreesListViewModel
    {
        //PK
        [Key]
        public int DegreeID { get; set; }
        //FK
        [ForeignKey("ProgramManagers")]
        public int ProgramManagerID { get; set; }
        [ForeignKey("College")]
        public int SchoolID { get; set; }

        [Required]
        [Display(Name = "Admission Details")]
        public string AdmissionsSummary { get; set; }

        //[Required]
        //[Display(Name = "Required Credits")]
        //public int RequiredCredits { get; set; }

        [Required]
        [StringLength(256)]
        public string DegreeName { get; set; }

        [Required]
        public string DegreeDescription { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string ProgramURL { get; set; }

        [Required]
        public string SchoolName { get; set; }

        [Required]
        public string ProgramManagerName { get; set; }

        [Required]
        public string ProgramManagerEmail { get; set; }

        public List<BASMockSite.Models.ProgramEntry> ProgramEntries { get; set; }
        

    }
}
