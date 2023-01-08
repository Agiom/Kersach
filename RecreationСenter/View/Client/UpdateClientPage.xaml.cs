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

namespace RecreationСenter.View.Client
{
    public partial class UpdateClientPage : Page
    {
        private FormClient _formClient;

        public UpdateClientPage(object o)
        {
            InitializeComponent();

            _formClient = (o as Button).DataContext as FormClient;

            TxbFIO.Text = _formClient.FIOClient;
            TxbPassNumber.Text = _formClient.passNumber;
            TxbPassSeria.Text = _formClient.passSeria;
            TxbAddress.Text = _formClient.address;
            TxbPhone.Text = _formClient.phone;
        }

        private void BtnClientUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _formClient.FIOClient = TxbFIO.Text;
                _formClient.passNumber = TxbPassNumber.Text;
                _formClient.passSeria = TxbPassSeria.Text;
                _formClient.address = TxbAddress.Text;
                _formClient.phone = TxbPhone.Text;
                Connect.DB.SaveChanges();

                MessageBox.Show("Информация была обновлена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                Connect.MyFrame.Navigate(new MainClientPage());
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show(_formClient.FIOClient, "Удалить клиента?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    Connect.DB.FormClient.Remove(_formClient);
                    Connect.DB.SaveChanges();

                    MessageBox.Show("Клиент был удален", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                    Connect.MyFrame.Navigate(new MainClientPage());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new AddClientPage());
        }

        private void BackClient_Click(object sender, RoutedEventArgs e)
        {
            Connect.MyFrame.Navigate(new MainClientPage());
        }
    }
}