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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Threading;
using eulei.com.MIS.ClientConnection;
using eulei.com.MIS.Main.ViewModels;
using eulei.com.MIS.Main.Commands;
using System.IO;
namespace eulei.com.MIS.Main
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.Unloaded += MainWindow_Unloaded;
        }

        void MainWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            var serializer = new Xceed.Wpf.AvalonDock.Layout.Serialization.XmlLayoutSerializer(dockManager);
            serializer.Serialize(@".\AvalonDock.config");
        }


        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var serializer = new Xceed.Wpf.AvalonDock.Layout.Serialization.XmlLayoutSerializer(dockManager);
            serializer.LayoutSerializationCallback += (s, args) =>
            {
                args.Content = args.Content;
            };

            if (File.Exists(@".\AvalonDock.config"))
                serializer.Deserialize(@".\AvalonDock.config");

            theme.Items.Add("BureauBlack");
            theme.Items.Add("BureauBlue");
            theme.Items.Add("ExpressionDark");
            theme.Items.Add("ExpressionLight");
            theme.Items.Add("ShinyBlue");
            theme.Items.Add("ShinyRed");
            theme.Items.Add("WhistlerBlue");
        }

        private void dockManager_DocumentClosing(object sender, Xceed.Wpf.AvalonDock.DocumentClosingEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {         
            string dicName = string.Format( 
                "themes/{0}.xaml",((ComboBox)sender).SelectedValue.ToString() );  
            this.Resources = (ResourceDictionary)(Application.LoadComponent(  
                new Uri(dicName,UriKind.Relative)));
        }

        private void OnLayoutRootPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void AddTwoDocuments_click(object sender, RoutedEventArgs e)
        {

        }

        private void OnToolWindow1Hiding(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }





    }
}
