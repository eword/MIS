using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using eulei.com.MIS.ClientConnection.MISService;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
namespace eulei.com.MIS.ClientConnection
{

    public class ClientCon : IDisposable
    {

        public MISServiceClient Client;
        public ClientCon()
        {
            try
            {
                Client = new MISServiceClient(ClinetConnectionParameters.EndpointConfigurationName);
                string _path = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ClientCertificate"].ToString();
                string _password = ConfigurationManager.AppSettings["ClientCertificatePassword"].ToString();
                Client.ClientCredentials.ClientCertificate.Certificate = new X509Certificate2(_path, _password, X509KeyStorageFlags.MachineKeySet);
                Client.Open();            
            }
            catch (SecurityNegotiationException ex)
            {
                throw new Exception("通讯连接失败，可能原因如下：\r\n" + ex.Message + ex.GetType().ToString());
            }
            catch (MessageSecurityException ex)
            {
                throw new Exception("登入失败：账号密码错误！可能原因如下：\r\n" + ex.Message + ex.GetType().ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("异常，可能原因如下：\r\n" + ex.Message+ex.GetType().ToString());
            }
       
        }
        public void Dispose()
        {
            Client.Close();
        }
    }
    //单例模式
    //public class ClientCon:IDisposable
    //{
    //    private static ClientCon _instance;

    //    public MISServiceClient Client;
    //    private ClientCon()
    //    {
    //        Client = new MISServiceClient("WSHttpBinding_IMISService");         
    //        Client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["UserName"].ToString();
    //        Client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PassWord"].ToString();     
    //    }
    //    public static ClientCon GetInstance()
    //    {
    //        if (_instance == null||_instance.Client.State.Equals(CommunicationState.Closed))
    //        {
    //            _instance = new ClientCon();
    //        }         
    //        return _instance;
    //    }

    //    public void Dispose()
    //    {
    //        _instance.Client.Close();     
    //    }
    //}
}
