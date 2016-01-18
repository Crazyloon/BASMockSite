using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BASMockSite.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASMockSite.ViewModels.BASManagers
{
    public class BASMenu
    {
        [Key]
        public int ManagerID { get; set; }

        public ProgramManager Manager { get; set; }
        public College College { get; set; }        
        [NotMapped]
        public ICollection<Models.Degree> Degrees { get; set; }
    }
}
