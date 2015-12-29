using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.Models
{
    public enum CourseStructure
    { 
        [Display(Name = "Daytime")]
        Daytime,
        [Display(Name = "Evening")]
        Evening,
        [Display(Name = "Online")]
        Online,
        [Display(Name = "Hybrid")]
        Hybrid,
        [Display(Name = "Part-time")]
        PartTime,
        [Display(Name = "Full time")]
        FullTime,
        [Display(Name = "Daily")]
        Daily
    }
}
