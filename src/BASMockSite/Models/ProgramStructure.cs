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
        [ForeignKey("ProgramEntry")]
        public int ProgramEntrylID { get; set; }

        [Required]
        public CourseStructure Structure { get; set; }

        // Like: 6 quarters
        [Required]
        [Display(Name = "Program Length")]
        public string ProgramDuration { get; set; }

        // Navigation Property
        public virtual ProgramEntry ProgramEntry { get; set; }
    }
}
 