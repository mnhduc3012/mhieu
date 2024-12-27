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
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        private readonly ICustomerService customerService;
        public EditCustomer()
        {
            InitializeComponent();
            customerService = new CustomerService();
        }

        public Customer EditedCustomer { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var status = new string[] { "Active", "Deleted" };
            cbxCustomerStatus.ItemsSource = status;

            txtCustomerID.Text = EditedCustomer.CustomerID.ToString();
            txtCustomerFullName.Text = EditedCustomer.CustomerFullName;
            txtTelephone.Text = EditedCustomer.Telephone;
            txtEmailAddress.Text = EditedCustomer.EmailAddress;
            dpCustomerBirthday.Text = EditedCustomer.CustomerBirthday.ToString();
            cbxCustomerStatus.SelectedItem = EditedCustomer.CustomerStatus == 1 ? "Active" : "Deleted";
            txtPassword.Text = EditedCustomer.Password;
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

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var cus = GetCustomerForm();
            if(cus == null)
            {
                return;
            }

            var x = customerService.GetCustomer(cus.CustomerID);

            if (x == null)
            {
                MessageBox.Show("Id is not existed !");
                return;
            }

            customerService.UpdateCustomer(cus);
            this.Close();
        }
    }
}
