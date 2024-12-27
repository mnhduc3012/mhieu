using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomInformationRepository : IRoomInformationRepository
    {
        public void Add(RoomInformation x) => RoomInformationDAO.INSTANCE.Add(x);

        public void Delete(int id) => RoomInformationDAO.INSTANCE.Delete(id);

        public List<RoomInformation> GetAll() => RoomInformationDAO.INSTANCE.GetAll();

        public RoomInformation GetById(int id) => RoomInformationDAO.INSTANCE.GetById(id);

        public void Update(RoomInformation x) => RoomInformationDAO.INSTANCE.Update(x);
    }
}
