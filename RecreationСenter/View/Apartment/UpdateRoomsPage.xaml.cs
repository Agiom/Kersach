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

namespace RecreationСenter.View.Apartment
{
    /// <summary>
    /// Логика взаимодействия для UpdateRoomsPage.xaml
    /// </summary>
    public partial class UpdateRoomsPage : Page
    {
        private Rooms _rooms;

        public UpdateRoomsPage(object o)
        {
            InitializeComponent();

            _rooms = (o as Button).DataContext as Rooms;

            TxbNumberRoom.Text = Convert.ToString(_rooms.numberRoom);
            TxbPrice.Text = Convert.ToString(_rooms.price);
            TxbAmountPlaces.Text = Convert.ToString(_rooms.amountPlaces);
            TxbAmountFreePlaces.Text = Convert.ToString(_rooms.amountFreePlaces);

        }

        private void BackRoom_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new MainRoomsPage());
        }

        private void BtnRoomUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _rooms.numberRoom = Convert.ToInt32(TxbNumberRoom.Text);
                _rooms.price = Convert.ToDecimal(TxbPrice.Text);
                _rooms.amountPlaces = Convert.ToInt16(TxbAmountPlaces.Text);
                _rooms.amountFreePlaces = Convert.ToInt16(TxbAmountFreePlaces.Text);
                Connect.DB.SaveChanges();

                MessageBox.Show("Информация была обновлена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                Connect.MyFrame.Navigate(new MainRoomsPage());
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show(Convert.ToString(_rooms.numberRoom), "Удалить комнату?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    Connect.DB.Rooms.Remove(_rooms);
                    Connect.DB.SaveChanges();

                    MessageBox.Show("Комната была удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                    Connect.MyFrame.Navigate(new MainRoomsPage());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new AddRoomsPag());
        }
    }
}
