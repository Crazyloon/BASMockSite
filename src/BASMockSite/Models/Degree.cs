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
        [ForeignKey("Program Manager")]
        public int ProgramManagerID { get; set; }
        [Display(Name = "College")]
        [ForeignKey("College")]
        public int CollegeID { get; set; }

        [Required]
        [Display(Name = "Application Details")]
        [StringLength(256, ErrorMessage = "Application details should be 256 characters or less")]
        public string AdmissionsSummary { get; set; }

        [Required]
        [Display(Name = "Required Credits")]
        [Range(minimum: 50, maximum: 240)]
        public int RequiredCredits { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(128, ErrorMessage = "Enter a degree title of 128 characters or less.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(2000, ErrorMessage = "Your description is too long, reduce it to 2000 characters or less.")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Program URL")]
        [DataType(DataType.Url)]
        public string ProgramURL { get; set; }
        
        public virtual College College { get; set; }
        public virtual ProgramManager ProgramManager { get; set; }
        public virtual ICollection<ProgramEntry> ProgramEntries { get; set; }
    }
}
