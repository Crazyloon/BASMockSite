using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BASMockSite.Models
{
    public enum EntrySeason
    {
        [Display(Name = "Winter")]
        Winter,
        [Display(Name = "Spring")]
        Spring,
        [Display(Name = "Summer")]
        Summer,
        [Display(Name = "Fall")]
        Fall
    }
}
