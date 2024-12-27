using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRoomInformationService
    {
        List<RoomInformation> GetRoomInformationList();

        RoomInformation GetRoomInformation(int id);

        void AddRoomInformation(RoomInformation x);

        void DeleteRoomInformation(int id);

        void UpdateRoomInformation(RoomInformation x);

        List<RoomInformation> SearchByPrice(decimal? min, decimal? max);


    }
}
