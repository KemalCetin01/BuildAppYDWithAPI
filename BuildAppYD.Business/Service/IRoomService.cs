using BuildAppYD.Core.Utilities.Results;
using BuildAppYD.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAppYD.Business.Service
{
    public interface IRoomService
    {
        IDataResult<List<Room>> getList();
        IDataResult<List<Room>> GetListWtihBuilding();
        IDataResult<Room> getById(int Id);
        IResult Add(Room room);
        IResult Delete(Room room);
        IResult Update(Room room);
        IDataResult<List<Room>> getListByBuildingId(int buildingId);
    }
}
