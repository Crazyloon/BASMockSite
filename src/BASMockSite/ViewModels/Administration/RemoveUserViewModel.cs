using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.ViewModels.Administration
{
    public class RemoveUserViewModel
    {
        public RemoveUserViewModel()
        {
            Users = new List<SelectListItem>();
        }

        public List<SelectListItem> Users { get; set; }
        public string UserName { get; set; }
    }
}
