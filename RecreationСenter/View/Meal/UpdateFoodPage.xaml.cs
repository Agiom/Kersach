using RecreationСenter.Core;
using RecreationСenter.Model;
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
    /// Логика взаимодействия для UpdateFoodPage.xaml
    /// </summary>
    public partial class UpdateFoodPage : Page
    {
        private Food _food;

        public UpdateFoodPage(object o)
        {
            InitializeComponent();

            _food = (o as Button).DataContext as Food;

            TxbTitle.Text = _food.title;
            TxbPrice.Text = Convert.ToString(_food.price);
            TxbTime.Text = Convert.ToString(_food.time);
            TxbQuantityPerson.Text = Convert.ToString(_food.quantityPerson);
        }

        private void BtnFoodUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _food.title = TxbTitle.Text;
                _food.price = Convert.ToDecimal(TxbPrice.Text);
                _food.time = TimeSpan.Parse(TxbTime.Text);
                _food.quantityPerson = Convert.ToInt16(TxbQuantityPerson.Text);
                Connect.DB.SaveChanges();

                MessageBox.Show("Информация была обновлена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

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

        private void BtnDeleteFood_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show(_food.title, "Удалить питание?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    Connect.DB.Food.Remove(_food);
                    Connect.DB.SaveChanges();

                    MessageBox.Show("Питание было удалено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                    Connect.MyFrame.Navigate(new MainFoodPage());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAddFood_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new AddFoodPage());
        }
    }
}
