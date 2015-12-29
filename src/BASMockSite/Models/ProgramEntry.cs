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
        //[ForeignKey("School")]
        //public int SchoolID { get; set; }
        //FK
        [ForeignKey("Degree")]
        public int DegreeID { get; set; }

        // FIELDS

        [Display(Name = "Application Deadline")]
        public DateTime ApplicationDeadline { get; set; }

        //NAVIGATIONS
        
        public virtual ICollection<ProgramStructure> Structures { get; set; }
        public virtual EntrySeason Season { get; set; }
        //public virtual School School { get; set; }
        public virtual Degree Degree { get; set; }
    }
}
