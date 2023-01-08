using RecreationСenter.Core;
using RecreationСenter.Model;
using RecreationСenter.View;
using System;
using System.Collections;
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

namespace RecreationСenter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Connect.DB = new RelaxBDEntities();
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

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnSingUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FormClient clientModel = Connect.DB.FormClient.FirstOrDefault(f => f.FIOClient == TxbLogin.Text && f.phone == PsbPassword.Password);

                if (clientModel == null)
                {
                    MessageBox.Show("Данные не верны", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (clientModel.clientID)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            Application.Current.Shutdown();
                            break;
                        case 5:
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();
                            this.Hide();
                            break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
