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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly ICustomerService _customerService;

        private int customerId;
        public CustomerWindow(int id)
        {
            InitializeComponent();
            customerId = id;
            _customerService = new CustomerService();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var cus = GetCustomerForm();
            if (cus == null)
            {
                this.Close(); return;
            }
            _customerService.UpdateCustomer(cus);
        }
        private Customer? GetCustomerForm()
        {
            try
            {
                Customer customer = new Customer
                {
                    CustomerID = int.Parse(txtCustomerID.Text),
                    CustomerFullName = txtCustomerFullName.Text,
                    Telephone = txtTelephone.Text,
                    EmailAddress = txtEmailAddress.Text,
                    CustomerBirthday = DateOnly.Parse(dpCustomerBirthday.Text),
                    CustomerStatus = _customerService.GetCustomer(customerId).CustomerStatus,
                    Password = txtPassword.Text
                };
                return customer;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow l = new LoginWindow();
            l.Show();
            this.Close();
        }

        private void Load()
        {
            var customer = _customerService.GetCustomer(customerId);
            txtCustomerID.Text = customer.CustomerID.ToString();
            txtCustomerFullName.Text = customer.CustomerFullName;
            txtTelephone.Text = customer.Telephone;
            txtEmailAddress.Text = customer.EmailAddress;
            dpCustomerBirthday.Text = customer.CustomerBirthday.ToString();
            txtPassword.Text = customer.Password;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Load();

        }
    }
}
