using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel;
using System.IdentityModel.Selectors;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.IdentityModel.Tokens;
namespace eulei.com.MIS.Host.Code
{
    public class ServiceX509CertificateValidator : X509CertificateValidator 
    {
        public override void Validate(X509Certificate2 certificate)
        {

            string _path = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ClientCertificate"].ToString();
            string _password = ConfigurationManager.AppSettings["ClientCertificatePassword"].ToString();
            if (!File.Exists(_path))
            {

                throw new FileNotFoundException(Path.GetFileName(_path));

            }

            X509Certificate2 clientCertificate = new X509Certificate2(_path, _password, X509KeyStorageFlags.MachineKeySet);

            //This is the Client  Certificate Thumbprint,In Production,We can validate the Certificate With CA

            if (!certificate.Thumbprint.Equals(clientCertificate.Thumbprint, StringComparison.CurrentCultureIgnoreCase))
            {

                throw new SecurityTokenException("Unknown Certificate");

            }

        }
    }
}
