using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASMockSite.Models
{
    public class Degree
    {
        //PK
        [Key]
        public int DegreeID { get; set; }
        //FK
        [ForeignKey("ProgramManager")]
        public int ProgramManagerID { get; set; }
        [ForeignKey("School")]
        public int SchoolID { get; set; }

        [Required]
        [Display(Name = "Admission Details")]
        public string AdmissionsSummary { get; set; }

        [Required]
        [Display(Name = "Required Credits")]
        public int RequiredCredits { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string ProgramURL { get; set; }
        
        public virtual School School { get; set; }
        public virtual ProgramManager ProgramManager { get; set; }
        public virtual ICollection<ProgramEntry> ProgramEntries { get; set; }
    }
}
