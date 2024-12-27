using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomInformationRepository
    {
        List<RoomInformation> GetAll();
        RoomInformation GetById(int id);

        void Add(RoomInformation x);

        void Update(RoomInformation x);

        void Delete(int id);
    }
}
