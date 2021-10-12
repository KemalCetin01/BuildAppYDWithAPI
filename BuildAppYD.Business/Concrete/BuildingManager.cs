using BuildAppYD.Business.Constants;
using BuildAppYD.Business.Service;
using BuildAppYD.Core.Utilities.Business;
using BuildAppYD.Core.Utilities.Results;
using BuildAppYD.DataAccess.Service;
using BuildAppYD.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAppYD.Business.Concrete
{
    public class BuildingManager : IBuildingService
    {
       private IBuildingDal _buildingDal;
        private IRoomDal _roomDal;
        private IStoreDal _storeDal;
        public BuildingManager(IBuildingDal buildingDal,IRoomDal roomDal,IStoreDal storeDal)
        {
            _buildingDal = buildingDal;
            _roomDal = roomDal;
            _storeDal = storeDal;

        }
        public IResult Add(Building building)
        {
            IResult result = BusinessRules.Run(CheckIfBuildingNameExists(building.buildingName)); //Birden Fazla Kontrolü bir sürü if-else ile yapmamak için method yazıldı 
            if (result != null)
            {
                return result;
            }
            _buildingDal.Add(building);
            return new SuccessResult(Messages.BuildingAdded);
        }

        private IResult CheckIfBuildingNameExists(string buildingName)
        {
            var result = _buildingDal.GetList(p => p.buildingName == buildingName).Any();
            if (result)
            {
                return new ErrorResult(Messages.BuildingNameAlreadyExists);
            }

            return new SuccessResult();
        }

        public IResult Delete(Building building)
        {
            IResult result = BusinessRules.Run(CheckIfStoreExistsDeleteThis(building.Id), CheckIfRoomExistsDeleteThis(building.Id));
            //Bina Silindiğinde bağlı olduğu oda ve depo varsa bunlar da silinir

            _buildingDal.Delete(building);
            return new SuccessResult(Messages.BuildingDeleted);
        }

        private IResult CheckIfRoomExistsDeleteThis(int id)
        {
            var result = _roomDal.GetList(p=>p.BuildingId==id).Any();
            if (result)
            {
                List<Room> rooms = _roomDal.GetList(p => p.BuildingId == id).ToList();
                foreach (var item in rooms)
                {
                    _roomDal.Delete(item);
                }
                return new SuccessResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfStoreExistsDeleteThis(int id)
        {
            var result = _storeDal.GetList(p => p.BuildingId == id).Any();
            if (result)
            {
                List<Store> rooms = _storeDal.GetList(p => p.BuildingId == id).ToList();
                foreach (var item in rooms)
                {
                    _storeDal.Delete(item);
                }
                return new SuccessResult();
            }

            return new SuccessResult();
        }

        public IEnumerable<Building> getList()
        {
            return _buildingDal.GetList();
        }

        public IResult Update(Building building)
        {
            _buildingDal.Update(building);
            return new SuccessResult(Messages.BuildingUpdated);
        }

        public IDataResult<Building> getById(int Id)
        {
            return new SuccessDataResult<Building>(_buildingDal.Get(p => p.Id == Id));

        }

        public IDataResult<Building> getDetail(int buildingId)
        {
            return new SuccessDataResult<Building>(_buildingDal.getDetail(buildingId));
        }

   


    }
}
