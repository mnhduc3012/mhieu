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

namespace FUMiniHotelManagement
{
    /// <summary>
    /// Interaction logic for NavBar.xaml
    /// </summary>
    public partial class NavBar : UserControl
    {

        private Frame _mainFrame;
        private MainWindow _mainWindow;
        public NavBar(Frame mainFrame, MainWindow mainWindow)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            _mainWindow = mainWindow;
        }

        private void btnRoom_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new RoomManagement());
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new CustomerManagement());
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow l = new LoginWindow();
            l.Show();
            _mainWindow.Close();
        }
    }
}
