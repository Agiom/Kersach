using RecreationСenter.Core;
using RecreationСenter.Model;
using RecreationСenter.View.Apartment;
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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        public AddClientPage()
        {
            InitializeComponent();
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Connect.DB.FormClient.Add(new Model.FormClient
                {
                    FIOClient = TxbIngredient.Text,
                    passNumber = TxbUnitofmeasurement.Text,
                    passSeria = TxbWeight.Text,
                    address = TxbPriceperunit.Text,
                    phone = TxbPriceperunit.Text
                });
                Connect.DB.SaveChanges();
                MessageBox.Show("Новый клиент добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Connect.MyFrame.Navigate(new MainClientPage());
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackClient_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new MainClientPage());
        }
    }
}
