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

        // Like 90 Credits, 6 quarters
        public string ProgramDuration { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string ProgramURL { get; set; }
        //Nav props

        public virtual School School { get; set; }
        public virtual ProgramManager ProgramManager { get; set; }
        public virtual ICollection<CourseModel> CourseModels { get; set; }
    }
}
