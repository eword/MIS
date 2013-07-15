using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Xml.Linq;
namespace eulei.com.AutoUpdater
{
    public class Constants
    {
        public static string RemoteUrl
        {
            get
            {

                XDocument xDoc = XDocument.Load(System.AppDomain.CurrentDomain.BaseDirectory + "AutoUpdateConfig.xml");
                UpdateInfo updateInfo = new UpdateInfo();
                XElement root = xDoc.Element("AutoUpdate");
                return root.Element("baseUrl").Value.Trim();
            }
        }

    }
}