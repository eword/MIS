using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using eulei.com.MIS.ClientConnection;
namespace eulei.com.MIS.Main
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void bt_login(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_userName.Text))
            {
                MessageBox.Show("请输入账号！");
                return;
            }
            if (string.IsNullOrEmpty(tb_passWord.Password))
            {
                MessageBox.Show("请输入密码！");
                return;
            }
            ClinetConnectionParameters.UserName = tb_userName.Text;
            ClinetConnectionParameters.PassWord = tb_passWord.Password;
            try
            {
                using (ClientCon _cl = new ClientCon())
                {
                    MessageBox.Show("验证成功1" + _cl.Client.getDate(), "提醒", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                }
            }
            catch(Exception ex){
                MessageBox.Show("失败：\r\n"+ex.Message, "提醒", MessageBoxButton.OK, MessageBoxImage.Error);
            }
    
        }

        private void bt_cancel(object sender, RoutedEventArgs e)
        {

        }

        private void bt_set(object sender, RoutedEventArgs e)
        {

        }

        private void bt_update(object sender, RoutedEventArgs e)
        {
            eulei.com.AutoUpdater.Updater.CheckUpdateStatus(true);
        }

    
    }
}
