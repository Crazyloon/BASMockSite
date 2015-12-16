using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.Models
{
    public class CourseModel
    {
        [Key]
        public int ModelID { get; set; }

        public ModelType Structure { get; set; }
        
        public virtual Degree Degree { get; set; }
    }

    public enum ModelType
    {
        Day,
        Night,
        Online,
        Hybrid
    }
}
