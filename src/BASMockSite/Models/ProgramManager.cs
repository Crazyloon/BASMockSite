using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASMockSite.Models
{
    // A program manager is the person in charge of each degree-page of the degree they manage.
    // they will have access to edit details from the Degree model and possibly the School model
    public class ProgramManager
    {
        //PK
        [Key]
        public int ManagerID { get; set; }
        //FK
        //[ForeignKey("School")]
        //public int SchoolID { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email address is a required field")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        //public virtual School School { get; set; }
        public virtual ICollection<Degree> Degree { get; set; }
    }
}