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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        private readonly ICustomerService _customerService;
        public AddCustomer()
        {
            InitializeComponent();
            _customerService = new CustomerService();
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
                    CustomerStatus = cbxCustomerStatus.SelectedItem.Equals("Active") ? 1 : 2,
                    Password = txtPassword.Text
                };
                return customer;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var customer = GetCustomerForm();

            if (customer == null)
            {
                return;
            }
            var x = _customerService.GetCustomer(customer.CustomerID);

            if (x != null)
            {
                MessageBox.Show("Id is alread existed !");
                return;
            }

            _customerService.AddCustomer(customer);

            this.Close();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var status = new string[] { "Active", "Deleted" };
            cbxCustomerStatus.ItemsSource = status;
            cbxCustomerStatus.SelectedIndex = 0;
        }
    }
}
