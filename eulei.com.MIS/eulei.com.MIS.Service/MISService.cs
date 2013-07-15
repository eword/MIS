using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eulei.com.MIS.Contracts;
using System.ServiceModel;
namespace eulei.com.MIS.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, Namespace = "http://www.bingosoft.net/lefay/")]
    public class MISService : IMISService
    {
   
        public string getDate()
        {
            return "test OK!";
        }
    }
}
