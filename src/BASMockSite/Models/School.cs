using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BASMockSite.Models
{
    public class School
    {
        [Key]
        public int SchoolID { get; set; }

        [Required]
        public bool Accredited { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
        
        [Required]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Enter a number like 1112223333")]
        public string MainPhone { get; set; }

        [Required]
        public string HomeWebAddress { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Tuition { get; set; }

        public byte[] Logo { get; set; }

        // Foreign tables
        //public ICollection<ProgramEntry> ProgramEntries { get; set; }
        public ICollection<Degree> Degrees { get; set; }
    }
}
