using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace eulei.com.MIS.ClientConnection
{
    public class ClinetConnectionParameters
    {
        public static string UserName;
        public static string PassWord;
        public static string EndpointConfigurationName = ConfigurationManager.AppSettings["endpointConfigurationName"].ToString();
    }
}
