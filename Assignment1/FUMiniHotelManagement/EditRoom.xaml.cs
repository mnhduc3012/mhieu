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
    /// Interaction logic for EditRoom.xaml
    /// </summary>
    public partial class EditRoom : Window
    {
        private readonly IRoomTypeService roomTypeService;
        private readonly IRoomInformationService roomInformationService;
        public EditRoom()
        {
            InitializeComponent();
            roomTypeService = new RoomTypeService();
            roomInformationService = new RoomInformationService();
        }

        public RoomInformation EditedRoom { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var roomStatus = new string[] { "Active", "Deleted" };
            cbxRoomStatus.ItemsSource = roomStatus;

            var roomTypes = roomTypeService.GetRoomTypes();
            cbxRoomType.ItemsSource = roomTypes;
            cbxRoomType.DisplayMemberPath = "RoomTypeName";
            cbxRoomType.SelectedValuePath = "RoomTypeID";

            txtRoomID.Text = EditedRoom.RoomID.ToString();
            txtRoomNumber.Text = EditedRoom.RoomNumber;
            txtRoomDescription.Text = EditedRoom.RoomDescription;
            txtRoomMaxCapacity.Text = EditedRoom.RoomMaxCapacity.ToString();
            cbxRoomStatus.SelectedItem = EditedRoom.RoomStatus == 1 ? "Active" : "Deleted";
            txtRoomPricePerDay.Text = EditedRoom.RoomPricePerDay.ToString();
            cbxRoomType.SelectedValue = EditedRoom.RoomTypeID;



            
        }
        private RoomInformation? GetRoomForm()
        {

            try
            {
                int roomId = int.Parse(txtRoomID.Text);
                string roomNumber = txtRoomNumber.Text;
                string roomDescription = txtRoomDescription.Text;
                int maxCapicity = int.Parse(txtRoomMaxCapacity.Text);
                int status = cbxRoomStatus.SelectedItem.ToString().Equals("Active") ? 1 : 2;
                decimal PricePerDay = decimal.Parse(txtRoomPricePerDay.Text);
                int RoomTypeId = int.Parse(cbxRoomType.SelectedValue.ToString());

                return new RoomInformation
                {
                    RoomID = roomId,
                    RoomNumber = roomNumber,
                    RoomDescription = roomDescription,
                    RoomMaxCapacity = maxCapicity,
                    RoomPricePerDay = PricePerDay,
                    RoomStatus = status,
                    RoomTypeID = RoomTypeId
                };
            }
            catch (Exception e)
            {
                return null;
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var room = GetRoomForm();

            if (room == null)
            {
                MessageBox.Show("Invalid input !");
                return;
            }

            var x = roomInformationService.GetRoomInformation(room.RoomID);

            if (x == null)
            {
                MessageBox.Show("ID is not existed !");
            }
            else
            {
                roomInformationService.UpdateRoomInformation(room);
                this.Close();
            }
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
