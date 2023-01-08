using RecreationСenter.Core;
using RecreationСenter.View.Apartment;
using RecreationСenter.View.Client;
using RecreationСenter.View.Meal;
using RecreationСenter.View.Residence;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RecreationСenter.View
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            Connect.MyFrame = AdminFrame;
            StartClock();
        }

        private void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickEvent;
            timer.Start();

        }

        private void tickEvent(object sender, EventArgs e)
        {
            ClockLbl.Text = DateTime.Now.ToString(@"yyyy-MM-dd HH\:mm");
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new MainClientPage());
        }

        private void BtnFood_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new MainFoodPage());
        }

        private void BtnResidence_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new MainResidencePage());
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {
            }
        }

        private void BtnRooms_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new MainRoomsPage());
        }

        private void BtnServices_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new MainServPage());
        }
    }
}
