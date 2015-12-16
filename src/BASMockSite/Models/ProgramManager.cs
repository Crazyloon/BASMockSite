using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BASMockSite.Models
{
    public class ProgramManager
    {
        [Key]
        public int ManagerID { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is a required field")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        public virtual School School { get; set; }

        public virtual ICollection<Degree> Degree { get; set; }

    }
}