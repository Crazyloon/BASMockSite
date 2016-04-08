using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASMockSite.Models
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }

        [ForeignKey("College")]
        public int CollegeID { get; set; }

        public string Title { get; set; }
        public string Alt { get; set; }
        public string Caption { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageURL { get; set; }

        public virtual College College { get; set; }
    }
}