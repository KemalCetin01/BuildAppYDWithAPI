using BuildAppYD.Core.DataAccess.EntityFramework;
using BuildAppYD.DataAccess.Concrete.EntityFramework.Contexts;
using BuildAppYD.DataAccess.Service;
using BuildAppYD.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BuildAppYD.DataAccess.Concrete.EntityFramework
{
    public class EfRoomDal : EfEntityRepositoryBase<Room, BuildAppYDContext>, IRoomDal
    {
        public List<Room> GetListWtihBuilding()
        {
            using (var context = new BuildAppYDContext())
            {
                return context.Rooms.Include(i => i.Buildings).ToList();
            }
        }

        public List<Room> GetRoomDetail(int buildingId)
        {
            using (var context = new BuildAppYDContext())
            {
                var rooms= context.Rooms.AsQueryable();
                rooms = rooms.Include(i => i.Buildings)
                    .Where(i => i.Buildings.Id == buildingId && i.BuildingId==buildingId);
                return rooms.ToList();
            }
        }
    }
}
