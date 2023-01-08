using RecreationСenter.Core;
using RecreationСenter.Model;
using RecreationСenter.View.Client;
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

namespace RecreationСenter.View.Meal
{
    /// <summary>
    /// Логика взаимодействия для AddFoodPage.xaml
    /// </summary>
    public partial class AddFoodPage : Page
    {
        public AddFoodPage()
        {
            InitializeComponent();
            Connect.MyFrame.Navigate(new MainFoodPage());
        }

        private void BtnAddFood_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Connect.DB.Food.Add(new Model.Food
                {
                    title = TxbTitle.Text,
                    price = Convert.ToDecimal(TxbPrice.Text),
                    time = TimeSpan.Parse(Convert.ToString(TxbTime.Text)),
                    quantityPerson = Convert.ToInt32(TxbQuantityPerson.Text),
                });
                Connect.DB.SaveChanges();
                MessageBox.Show("Новый клиент добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Connect.MyFrame.Navigate(new MainFoodPage());
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackFood_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new MainFoodPage());
        }
    }
}
