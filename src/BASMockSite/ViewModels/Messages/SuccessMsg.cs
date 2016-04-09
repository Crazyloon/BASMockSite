using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.ViewModels.Messages
{
    public class SuccessMsg : OperationMsg
    {
        public SuccessMsg(string message)
        {
            this.Message = message;
            this.OperationSuccessful = true;
        }
    }
}
