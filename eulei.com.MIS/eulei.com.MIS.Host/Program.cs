using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Configuration;
using System.IdentityModel;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using eulei.com.MIS.Service;
using System.IO;
namespace eulei.com.MIS.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            string _path = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ServiceCertificate"].ToString();
            string _password =ConfigurationManager.AppSettings["ServiceCertificatePassword"].ToString();
            if (!File.Exists(_path))
            {

                throw new FileNotFoundException(_path);

            }
            ServiceHost host = new ServiceHost(typeof(MISService));
            host.Credentials.ServiceCertificate.Certificate = new X509Certificate2(_path, _password, X509KeyStorageFlags.MachineKeySet);
            host.Opened += new EventHandler(host_Opened);
            host.Open();
            host.Closed += new EventHandler(host_Closed);


            //ServiceHost host1 = new ServiceHost(typeof(System.Web.ApplicationServices.AuthenticationService));
            //host1.Opened += new EventHandler(host1_Opened);
            //host1.Open();
            //host1.Closed += new EventHandler(host1_Closed);
        }

        static void host_Closed(object sender, EventArgs e)
        {
           // MsgConnection.Dispose();
            Console.WriteLine("服务成功开启");
            Console.ReadLine();
        }
        static void host_Opened(object sender, EventArgs e)
        {
           // MsgConnection.Connection();
            Console.WriteLine("服务成功开启");
            Console.ReadLine();
        }

        static void host1_Closed(object sender, EventArgs e)
        {
            // MsgConnection.Dispose();
            Console.WriteLine("身份验证服务成功开启");
            Console.ReadLine();
        }
        static void host1_Opened(object sender, EventArgs e)
        {
            // MsgConnection.Connection();
            Console.WriteLine("身份验证服务成功开启");
            Console.ReadLine();
        }
    }
}
