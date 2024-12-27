using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomInformationService : IRoomInformationService
    {
        private readonly IRoomInformationRepository _roomInformationRepository;

        public RoomInformationService()
        {
            _roomInformationRepository = new RoomInformationRepository();
        }

        public void AddRoomInformation(RoomInformation x) => _roomInformationRepository.Add(x);

        public void DeleteRoomInformation(int id) => _roomInformationRepository.Delete(id);

        public RoomInformation GetRoomInformation(int id) => _roomInformationRepository.GetById(id);

        public List<RoomInformation> GetRoomInformationList() => _roomInformationRepository.GetAll();

        public void UpdateRoomInformation(RoomInformation x) => _roomInformationRepository.Update(x);


        public List<RoomInformation> SearchByPrice(decimal? min, decimal? max)
        {
            List<RoomInformation> result = _roomInformationRepository.GetAll();

            if (min != null)
            {
                result = result.Where(x => x.RoomPricePerDay >= min).ToList();
            }
            if (max != null)
            {
                result = result.Where(x => x.RoomPricePerDay <= max).ToList();
            }
            return result;
        }
    }
}
