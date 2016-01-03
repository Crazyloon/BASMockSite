using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASMockSite.Models
{
    // A program manager is the person in charge of each degree-page of the degree they manage.
    // they will have access to edit details from the Degrees model and possibly the College model
    public class ProgramManager
    {
        //PK
        [Key]
        public int ManagerID { get; set; }

        //FK
        [ForeignKey("College")]
        [Display(Name = "College")]
        public int CollegeID { get; set; }

        [Required(ErrorMessage = "Enter the first and last name for this program manager")]
        [StringLength(128, ErrorMessage = "Enter a name of 128 characters or less.")]
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email address is a required field")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Enter a number like 1113335555")]
        public string Phone { get; set; }

        public virtual College College { get; set; }
        public virtual ICollection<Degree> Degrees { get; set; }
    }
}