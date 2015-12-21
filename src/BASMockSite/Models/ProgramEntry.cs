using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.Models
{
    public class ProgramEntry
    {
        [Key]
        public int EntryDateID { get; set; }        
        
        [Display(Name = "Application Deadline")]
        public DateTime ApplicationDeadline { get; set; }

        public string EntrySummary { get; set; }
        
        public EntrySeason Season { get; set; }

        public virtual CourseModel CourseModel { get; set; }
    }

    public enum EntrySeason
    {
        Winter,
        Spring,
        Summer,
        Fall,
        Always
    }
}
