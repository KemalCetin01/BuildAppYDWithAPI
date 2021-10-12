using BuildAppYD.Core.DataAccess;
using BuildAppYD.Entities.DTOs;
using System.Collections.Generic;

namespace BuildAppYD.DataAccess.Service
{
    public interface IStoreDal : IEntityRepository<Store>
    {
        List<Store> GetStoreDetail(int buildingId);
        List<Store> GetListWtihBuilding();
    }
}
