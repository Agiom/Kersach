using RecreationСenter.Core;
using RecreationСenter.Model;
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
    /// Логика взаимодействия для UpdateResidencePage.xaml
    /// </summary>
    public partial class UpdateResidencePage : Page
    {
        private ResidenceClients _residenceClients;

        public UpdateResidencePage(object o)
        {
            InitializeComponent();

            _residenceClients = (o as Button).DataContext as ResidenceClients;

            TxbRoomID.Text = Convert.ToString(_residenceClients.roomID);
            TxbArrivalDate.Text = Convert.ToString(_residenceClients.arrivalDate);
            TxbDepartureDate.Text = Convert.ToString(_residenceClients.departureDate);
            TxbFIOClient.Text = Convert.ToString(_residenceClients.clientID);
            TxbFoodID.Text = Convert.ToString(_residenceClients.foodID);
            TxbServiceID.Text = Convert.ToString(_residenceClients.serviceID);

        }

        private void BackResidence_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new MainResidencePage());
        }

        private void BtnResidenceUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _residenceClients.roomID = Convert.ToInt32(TxbRoomID.Text);
                _residenceClients.arrivalDate = Convert.ToDateTime(TxbArrivalDate.Text);
                _residenceClients.departureDate = Convert.ToDateTime(TxbDepartureDate.Text);
                _residenceClients.clientID = Convert.ToInt32(TxbFIOClient.Text);
                _residenceClients.foodID = Convert.ToInt32(TxbFoodID.Text);
                _residenceClients.serviceID = Convert.ToInt32(TxbServiceID.Text);
                Connect.DB.SaveChanges();

                MessageBox.Show("Информация была обновлена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                Connect.MyFrame.Navigate(new MainResidencePage());
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDeleteResidence_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show(Convert.ToString(_residenceClients.roomID), "Удалить комнату проживания?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    Connect.DB.ResidenceClients.Remove(_residenceClients);
                    Connect.DB.SaveChanges();

                    MessageBox.Show("Комната проживания была удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                    Connect.MyFrame.Navigate(new MainResidencePage());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAddResidence_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new AddResidencePage());
        }
    }
}
