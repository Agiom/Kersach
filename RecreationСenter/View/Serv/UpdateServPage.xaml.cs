using RecreationСenter.Model;
using RecreationСenter.Core;
using RecreationСenter.View.Serv;
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
using RecreationСenter.View.Apartment;

namespace RecreationСenter.View.Serv
{
    /// <summary>
    /// Логика взаимодействия для UpdateServPage.xaml
    /// </summary>
    public partial class UpdateServPage : Page
    {
        private Services _services;

        public UpdateServPage(object o)
        {
            InitializeComponent();

            _services = (o as Button).DataContext as Services;

            TxbTitle.Text = _services.titleService;
            TxbPrice.Text = Convert.ToString(_services.price);
        }

        private void BackService_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new MainServPage());
        }

        private void BtnServiceUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _services.titleService = TxbTitle.Text;
                _services.price = Convert.ToDecimal(TxbPrice.Text);
                Connect.DB.SaveChanges();

                MessageBox.Show("Информация была обновлена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                Connect.MyFrame.Navigate(new MainServPage());
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDeleteService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show(_services.titleService, "Удалить услугу?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    Connect.DB.Services.Remove(_services);
                    Connect.DB.SaveChanges();

                    MessageBox.Show("Услуга была удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                    Connect.MyFrame.Navigate(new MainServPage());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new AddServicesPage());
        }
    }
}
