using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class RoomInformation
    {
        public int RoomID { get; set; }
        public string? RoomNumber { get; set; }

        public string? RoomDescription { get; set; }

        public int RoomMaxCapacity { get; set; }

        public int RoomStatus { get; set; }

        public virtual string Status { get => RoomStatus == 1 ? "Active" : "Delected"; }
        public decimal RoomPricePerDay { get; set; }

        public int RoomTypeID { get; set; }

        public virtual RoomType? RoomType { get; set; }
    }
}
