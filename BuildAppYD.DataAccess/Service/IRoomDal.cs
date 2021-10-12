using BuildAppYD.Core.DataAccess;
using BuildAppYD.Entities.DTOs;
using System.Collections.Generic;

namespace BuildAppYD.DataAccess.Service
{
    public interface IRoomDal : IEntityRepository<Room>
    {
        List<Room> GetRoomDetail(int buildingId);
        List<Room> GetListWtihBuilding();
    }
}
