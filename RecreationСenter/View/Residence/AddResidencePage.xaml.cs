using RecreationСenter.Core;
using RecreationСenter.Model;
using RecreationСenter.View.Meal;
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
    /// Логика взаимодействия для AddResidencePage.xaml
    /// </summary>
    public partial class AddResidencePage : Page
    {
        public AddResidencePage()
        {
            InitializeComponent();
        }

        private void BackResidence_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new MainResidencePage());
        }

        private void BtnAddResidence_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Connect.DB.ResidenceClients.Add(new Model.ResidenceClients
                {
                    roomID = Convert.ToInt32(TxbRoomID.Text),
                    arrivalDate = Convert.ToDateTime(TxbArrivalDate.Text),
                    departureDate = Convert.ToDateTime(TxbDepartureDate.Text),
                    clientID = Convert.ToInt32(TxbFIOClient.Text),
                    foodID = Convert.ToInt32(TxbFoodID.Text),
                    serviceID = Convert.ToInt32(TxbServiceID.Text),

                });
                Connect.DB.SaveChanges();
                MessageBox.Show("Проживание клиента добавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Connect.MyFrame.Navigate(new MainResidencePage());
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
