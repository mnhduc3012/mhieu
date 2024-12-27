using BusinessObjects;
using Services;
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

namespace FUMiniHotelManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly ICustomerService _customerService;
        public LoginWindow()
        {
            InitializeComponent();
            _customerService = new CustomerService();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = pwbPassword.Password;

            Customer c = _customerService.Login(email, password);

            if (IsAdmin(email, password))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else if (c != null)
            {
                if (c.CustomerStatus == 2)
                {
                    MessageBox.Show("Your account is suspended !",
                "Login Failed",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
                    return;
                }

                CustomerWindow customerWindow = new CustomerWindow(c.CustomerID);
                customerWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect username or password !",
                "Login Failed",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);

            }


        }


        private bool IsAdmin(string email, string password)
        {
            string adminEmail = "admin";
            string adminPassword = "123";

            if (email.Equals(adminEmail) && password.Equals(adminPassword))
            {
                return true;
            }
            return false;

        }

    }
}
