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

namespace RecreationСenter.View.Apartment
{
    /// <summary>
    /// Логика взаимодействия для AddRoomsPag.xaml
    /// </summary>
    public partial class AddRoomsPag : Page
    {
        public AddRoomsPag()
        {
            InitializeComponent();
        }

        private void BackRoom_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new MainRoomsPage());
        }

        private void BtnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Connect.DB.Rooms.Add(new Model.Rooms
                {
                    numberRoom = Convert.ToInt32(TxbNumberRoom.Text),
                    price = Convert.ToDecimal(TxbPrice.Text),
                    amountPlaces = Convert.ToInt16(TxbAmountPlaces.Text),
                    amountFreePlaces = Convert.ToInt16(TxbAmountFreePlaces.Text),
                });
                Connect.DB.SaveChanges();
                MessageBox.Show("Новая комната добавлена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Connect.MyFrame.Navigate(new MainRoomsPage());
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
