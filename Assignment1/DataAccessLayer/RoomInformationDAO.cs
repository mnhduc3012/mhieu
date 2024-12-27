using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomInformationDAO
    {
        public static RoomInformationDAO INSTANCE = new();

        public RoomInformationDAO()
        {
            if (INSTANCE == null) INSTANCE = this;
        }

        private readonly List<RoomInformation> list = new List<RoomInformation>()
        {
            new RoomInformation{RoomID=1,RoomNumber="2364",RoomDescription="A basic room with essential amenities, suitable for individual travelers or couples.",RoomMaxCapacity=3,RoomTypeID=1,RoomStatus=1,RoomPricePerDay=149},
                new RoomInformation{RoomID=2,RoomNumber="3345",RoomDescription="Deluxe rooms offer additional features such as a balcony or sea view, upgraded bedding, and improved décor.",RoomMaxCapacity=5,RoomTypeID=3,RoomStatus=1,RoomPricePerDay=299},
                new RoomInformation{RoomID=3,RoomNumber="4432",RoomDescription="A luxurious and spacious room with separate living and sleeping areas, ideal for guests seeking extra comfort and space.",RoomMaxCapacity=4,RoomTypeID=2,RoomStatus=1,RoomPricePerDay=199}
        };
        public List<RoomInformation> GetAll()
        {
            return list;
        }


        public void Add(RoomInformation x)
        {
            list.Add(x);
        }

        public void Update(RoomInformation x)
        {
            foreach (var o in list)
            {
                if (o.RoomID == x.RoomID)
                {
                    o.RoomNumber = x.RoomNumber;
                    o.RoomDescription = x.RoomDescription;
                    o.RoomMaxCapacity = x.RoomMaxCapacity;
                    o.RoomTypeID = x.RoomTypeID;
                    o.RoomStatus = x.RoomStatus;
                    o.RoomPricePerDay = x.RoomPricePerDay;

                }
            }
        }

        public void Delete(int id)
        {
            var o = GetById(id);
            list.Remove(o);
        }

        public RoomInformation GetById(int id)
        {
            foreach (var o in list)
            {
                if (o.RoomID == id)
                {
                    return (RoomInformation)o;
                }
            }
            return null;
        }

    }
}
