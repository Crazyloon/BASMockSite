using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BASMockSite.ViewModels.Messages
{
    public class FailureMsg : OperationMsg
    {
        public FailureMsg(string message)
        {
            this.Message = message;
            this.OperationSuccessful = false;
        }
    }
}
