using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel.Selectors;
using System.IdentityModel;
using System.IO;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Tokens;
namespace eulei.com.MIS.ClientConnection
{
    public class ClientX509CertificateValidator : X509CertificateValidator
    {
        public override void Validate(X509Certificate2 certificate)
        {

            //throw new NotImplementedException();

            if (certificate == null)
            {

                throw new ArgumentNullException("certificate");

            }

            string _path = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ServiceCertificate"].ToString();
            string _password = ConfigurationManager.AppSettings["ServiceCertificatePassword"].ToString();
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
