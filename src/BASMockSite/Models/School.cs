using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BASMockSite.Models
{
    public class School
    {
        [Key]
        public int SchoolID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Tuition { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Entry Date")]
        public DateTime EntryDate { get; set; }

        public ICollection<Degree> Degrees { get; set; }
        public ICollection<ProgramManager> ProgramManagers { get; set; }
    }
}
