using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomTypeDAO
    {

        public static RoomTypeDAO INSTANCE = new();

        public RoomTypeDAO()
        {
            if (INSTANCE == null) INSTANCE = this;
        }

        public List<RoomType> GetAll()
        {
            var list = new List<RoomType>()
            {
                new RoomType{RoomTypeID=1,RoomTypeName="Standard room",TypeDescription="This is typically the most affordable option and provides basic amenities such as a bed, dresser, and TV." },
                new RoomType{RoomTypeID=2,RoomTypeName="Suite",TypeDescription="Suites usually offer more space and amenities than standard rooms, such as a separate living area, kitchenette, and multiple bathrooms." },
                new RoomType{RoomTypeID=3,RoomTypeName="Deluxe room",TypeDescription="Deluxe rooms offer additional features such as a balcony or sea view, upgraded bedding, and improved décor." },
                new RoomType{RoomTypeID=4,RoomTypeName="Executive room",TypeDescription="Executive rooms are designed for business travelers and offer perks such as free breakfast, evening drink, and high-speed internet." },
                new RoomType{RoomTypeID=5,RoomTypeName="Family Room",TypeDescription="A room specifically designed to accommodate families, often with multiple beds and additional space for children." }
            };
            return list;
        }
    }
}
