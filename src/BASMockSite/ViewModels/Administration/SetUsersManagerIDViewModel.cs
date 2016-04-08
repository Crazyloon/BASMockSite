using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.ViewModels.Administration
{
    public class SetUsersManagerIDViewModel
    {
        public SetUsersManagerIDViewModel()
        {
            Users = new List<SelectListItem>();
            BASManagers = new List<SelectListItem>();
        }

        public List<SelectListItem> Users { get; set; }
        public List<SelectListItem> BASManagers { get; set; }
        public string User { get; set; }
        public string BASManagerID { get; set; }
    }
}
