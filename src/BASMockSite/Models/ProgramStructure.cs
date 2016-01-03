using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.Models
{
    public class ProgramStructure
    {
        //PK
        [Key]
        public int ProgramStructureID { get; set; }
        //FK
        [ForeignKey("ProgramEntries")]
        public int ProgramEntrylID { get; set; }

        [Required(ErrorMessage = "Select a course structure from the list")]
        public CourseStructure Structure { get; set; }

        // Like: 6 quarters
        [Required]
        [Display(Name = "Program Length", Description = "The number of quarters a typical student attends class in order to earn a degree.")]
        public string ProgramDuration { get; set; }

        // Navigation Property
        public virtual ProgramEntry ProgramEntry { get; set; }
    }
}
 