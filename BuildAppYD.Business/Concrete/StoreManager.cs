using BuildAppYD.Business.Constants;
using BuildAppYD.Business.Service;
using BuildAppYD.Core.Utilities.Results;
using BuildAppYD.DataAccess.Service;
using BuildAppYD.Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace BuildAppYD.Business.Concrete
{
    public class StoreManager : IStoreService
    {
        IStoreDal _storeDal;
        public StoreManager(IStoreDal storeDal)
        {
            _storeDal = storeDal;
        }
        public IResult Add(Store store)
        {
            _storeDal.Add(store);
            return new SuccessResult(Messages.StoreAdded);
        }

        public IResult Delete(Store store)
        {
            _storeDal.Delete(store);
            return new SuccessResult(Messages.StoreDeleted);
        }

        public IDataResult<List<Store>> getList()
        {
            return new SuccessDataResult<List<Store>>(_storeDal.GetList().ToList());
        }
        public IDataResult<List<Store>> getListByBuildingId(int buildingId)
        {
            return new SuccessDataResult<List<Store>>(_storeDal.GetStoreDetail(buildingId).ToList());//??
        }
        public IResult Update(Store store)
        {
            _storeDal.Update(store);
            return new SuccessResult(Messages.StoreUpdated);
        }
        public IDataResult<Store> getById(int Id)
        {
            return new SuccessDataResult<Store>(_storeDal.Get(p => p.Id == Id));

        }

        public IDataResult<List<Store>> GetListWtihBuilding()
        {
            return new SuccessDataResult<List<Store>>(_storeDal.GetListWtihBuilding().ToList());
        }
    }
}
