using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BASMockSite.Models
{
    public class Degree
    {
        [Key]
        public int DegreeID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }



        //Nav props

        public virtual School School { get; set; }
        public virtual ICollection<ProgramEntryDate> EntryDates { get; set; }
        public virtual ICollection<CourseModel> CourseModels { get; set; }
    }
}
