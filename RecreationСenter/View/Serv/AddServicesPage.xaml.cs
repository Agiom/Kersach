using RecreationСenter.Core;
using RecreationСenter.Model;
using RecreationСenter.View.Residence;
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

namespace RecreationСenter.View.Serv
{
    /// <summary>
    /// Логика взаимодействия для AddServicesPage.xaml
    /// </summary>
    public partial class AddServicesPage : Page
    {
        public AddServicesPage()
        {
            InitializeComponent();
        }

        private void BackService_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new MainServPage());
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Connect.DB.Services.Add(new Model.Services
                {
                    titleService = TxbTitle.Text,
                    price = Convert.ToDecimal(TxbPrice.Text),
                });
                Connect.DB.SaveChanges();
                MessageBox.Show("Новая услуга добавлена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Connect.MyFrame.Navigate(new MainServPage());
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
