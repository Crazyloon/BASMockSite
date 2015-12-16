using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.Models
{
    public class ProgramEntryDate
    {
        [Key]
        public int EntryDateID { get; set; }

        [Required]
        [Display(Name = "Entry Date")]
        public DateTime EntryDate { get; set; }



        public virtual Degree Degree { get; set; }
    }
}
