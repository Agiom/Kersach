using RecreationСenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecreationСenter.View.Client
{
    /// <summary>
    /// Логика взаимодействия для MainClientPage.xaml
    /// </summary>
    public partial class MainClientPage : Page
    {
        public MainClientPage()
        {
            InitializeComponent();
            DataClientInfo.ItemsSource = Connect.DB.FormClient.ToList();
        }

        private void BtnUpdateClientInfo_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new UpdateClientPage(sender));
        }
    }
}
