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

namespace RecreationСenter.View.Meal
{
    /// <summary>
    /// Логика взаимодействия для MainFoodPage.xaml
    /// </summary>
    public partial class MainFoodPage : Page
    {
        public MainFoodPage()
        {
            InitializeComponent();
            DataFoodInfo.ItemsSource = Connect.DB.Food.ToList();
        }

        private void BtnUpdateInfo_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new UpdateFoodPage(sender));
        }

        private void BtnUpdateFoodInfo_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new UpdateFoodPage(sender));
        }


    }
}
