using BuildAppYD.Business.Constants;
using BuildAppYD.Business.Service;
using BuildAppYD.Core.Utilities.Business;
using BuildAppYD.Core.Utilities.Results;
using BuildAppYD.DataAccess.Service;
using BuildAppYD.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildAppYD.Business.Concrete
{
    public class RoomManager : IRoomService
    {
        private IRoomDal _roomDal;
        private IBuildingDal _buildingDal;
        public RoomManager(IRoomDal roomDal, IBuildingDal buildingDal)
        {
            _roomDal = roomDal;
            _buildingDal = buildingDal;
        }
        public IResult Add(Room room)
        {
            IResult result = BusinessRules.Run(CheckIfBuildingNotExists(room.BuildingId),CheckIfRoomExists(room.roomName));//Odanın bağlı olduğu bina yoksa veya Aynı oda ismi varsa
            if (result != null)
            {
                return result;
            }
            _roomDal.Add(room);
            return new SuccessResult(Messages.RoomAdded);

        }

        private IResult CheckIfRoomExists(string roomName)
        {
            var result = _roomDal.GetList(p=>p.roomName== roomName).Any();
            if (result)
            {
                return new ErrorResult(Messages.RoomNameAlreadyExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfBuildingNotExists(int buildingId)
        {
            var result = _buildingDal.GetList(p=>p.Id==buildingId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.BuildingNotExists);
            }
            return new SuccessResult();
        }

        public IResult Delete(Room room)
        {
            _roomDal.Delete(room);
            return new SuccessResult(Messages.RoomDeleted);
        }

        public IDataResult<List<Room>> getListByBuildingId(int buildingId)
        {
            return new SuccessDataResult<List<Room>>(_roomDal.GetRoomDetail(buildingId).ToList());//??
        }

        public IDataResult<List<Room>> getList()
        {
            return new SuccessDataResult<List<Room>>(_roomDal.GetList().ToList());
        }
        
        public IDataResult<List<Room>> GetListWtihBuilding()
        {
            return new SuccessDataResult<List<Room>>(_roomDal.GetListWtihBuilding().ToList());
        }

        public IResult Update(Room room)
        {
            _roomDal.Update(room);
            return new SuccessResult(Messages.RoomUpdated);
        }

        public IDataResult<Room> getById(int Id)
        {
            return new SuccessDataResult<Room>(_roomDal.Get(p=>p.Id==Id));

        }
    }
}
