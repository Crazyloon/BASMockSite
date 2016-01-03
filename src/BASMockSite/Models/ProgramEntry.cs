using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.Models
{
    public class ProgramEntry
    {
        // KEYS:

        //PK
        [Key]
        public int EntryID { get; set; }
        //FK
        //[ForeignKey("College")]
        //public int CollegeID { get; set; }
        //FK
        [ForeignKey("Degrees")]
        public int DegreeID { get; set; }

        // FIELDS

        [Required(ErrorMessage = "Select the Month and Day applications are due, Year will be omitted.")]
        [Display(Name = "Application Deadline", Description = "The Month and Day applications are due.")]
        public DateTime ApplicationDeadline { get; set; }

        //NAVIGATIONS
        
        public virtual ICollection<ProgramStructure> Structures { get; set; }
        public virtual EntrySeason Season { get; set; }
        //public virtual College College { get; set; }
        public virtual Degree Degree { get; set; }
    }
}
