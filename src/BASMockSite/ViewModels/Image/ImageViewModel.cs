using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Mvc.Rendering;

namespace BASMockSite.ViewModels.Image
{
    public class ImageViewModel
    {
        public SelectList CollegeID { get; set; }

        [Required]
        IFormFile ImageUpload { get; set; }
    }
}
