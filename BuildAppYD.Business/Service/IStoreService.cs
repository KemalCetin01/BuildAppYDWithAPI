using BuildAppYD.Core.Utilities.Results;
using BuildAppYD.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace BuildAppYD.Business.Service
{
   public interface IStoreService
    {
        IDataResult<List<Store>> getList();
        IDataResult<Store> getById(int Id);
        IResult Add(Store store);
        IResult Delete(Store store);
        IResult Update(Store store);
        IDataResult<List<Store>> getListByBuildingId(int buildingId);
        IDataResult<List<Store>> GetListWtihBuilding();
    }
}
