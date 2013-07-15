using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using eulei.com.AutoUpdater;
using System.Configuration;
namespace eulei.com.MIS.Main
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main1()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            if (
                ConfigurationManager.AppSettings["AutoUpdate"].ToString().Equals("true")
                )
            {
                eulei.com.AutoUpdater.Updater.CheckUpdateStatus(false);
            }
            LoginWindow loginForm = new LoginWindow();
            loginForm.InitializeComponent();
            bool? rt = loginForm.ShowDialog();
            loginForm.Close();
            if (rt == true)
            {
                App _app = new App();
                _app.ShutdownMode = ShutdownMode.OnMainWindowClose;
                MainWindow m_MianWindow = new MainWindow();
                _app.MainWindow = m_MianWindow;
                _app.Run(m_MianWindow);
            }
        }

    }
}
