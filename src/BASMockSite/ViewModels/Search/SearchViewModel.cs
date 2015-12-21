using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.ViewModels.Search
{
    public class SearchViewModel
    {
        public string CollegeName { get; set; }

        public string DegreeName { get; set; }

        public Models.ModelType ModelType { get; set; }

        public string County { get; set; }

        public string City { get; set; }
    }
}
