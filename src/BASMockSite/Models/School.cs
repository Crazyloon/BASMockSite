using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BASMockSite.Models
{
    public class College
    {
        [Key]
        public int CollegeID { get; set; }

        [Required]
        public bool Accredited { get; set; }

        [StringLength(128, ErrorMessage = "The name you entered is too long.")]
        [Required]
        public string Name { get; set; }

        [StringLength(32, ErrorMessage = "The address you entered is too long.")]
        [Required]
        public string Address { get; set; }

        [StringLength(64, ErrorMessage = "The city you entered is too long.")]
        [Required]
        public string City { get; set; }

        [StringLength(64, ErrorMessage = "The state you entered is too long.")]
        [Required]
        public string State { get; set; }
        
        [Required]
        [DataType(DataType.PostalCode, ErrorMessage = "A valid Postal Code must be used.")]
        public string Zip { get; set; }

        [Required]
        [Display(Name = "Main Phone")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Enter a number like 1112223333")]
        public string MainPhone { get; set; }

        [Required]
        [Display(Name = "Home Web Address")]
        [DataType(DataType.Url, ErrorMessage = @"Ensure your url begins with http:// and that it is a valid address")]
        public string HomeWebAddress { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(2000, ErrorMessage = "The description you entered is too long.")]
        public string Description { get; set; }

        // This could be made into an enum / select list in the future
        [Required]
        [Display(Name = "County")]
        [StringLength(64, ErrorMessage = "The county name you entered is too long.")]
        public string County { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal Tuition { get; set; }

        // This should probably be changed to an ImageURL at some point before release. There are only like 15 Community Colleges in Washington that offer BAS Degrees
        // but if the scope of the website gets much wider, then storing the images in byte arrays on the database becomes a poor solution.
        public byte[] Logo { get; set; }

        // In addition to a single logo, each college may want to provide a list of images as well
        
            // TODO: Add a public ICollection of CollegeImgs and add them to a photo reel on the College's page.
            // Limit to maybe 50 pictures or something...
        
        public virtual ICollection<Image> ImageURLs { get; set; }

        // Foreign tables
        //public ICollection<ProgramEntries> ProgramEntries { get; set; }
        public virtual ICollection<Degree> Degrees { get; set; }
        public virtual ICollection<ProgramManager> ProgramManagers { get; set; }
    }
}
