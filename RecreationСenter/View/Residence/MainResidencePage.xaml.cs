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

namespace RecreationСenter.View.Residence
{
    /// <summary>
    /// Логика взаимодействия для MainResidencePage.xaml
    /// </summary>
    public partial class MainResidencePage : Page
    {
        public MainResidencePage()
        {
            InitializeComponent();
            DataResidenceInfo.ItemsSource = Connect.DB.ResidenceClients.ToList();
        }

        private void BtnUpdateResidenceInfo_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new UpdateResidencePage(sender));
        }
    }
}
