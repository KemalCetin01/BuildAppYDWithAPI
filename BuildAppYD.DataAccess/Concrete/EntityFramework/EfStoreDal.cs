using BuildAppYD.Core.DataAccess.EntityFramework;
using BuildAppYD.DataAccess.Concrete.EntityFramework.Contexts;
using BuildAppYD.DataAccess.Service;
using BuildAppYD.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BuildAppYD.DataAccess.Concrete.EntityFramework
{
   public class EfStoreDal : EfEntityRepositoryBase<Store, BuildAppYDContext>, IStoreDal
    {
        public List<Store> GetStoreDetail(int buildingId)
        {
            using (var context = new BuildAppYDContext())
            {
                var stores = context.Stores.AsQueryable();
                stores = stores.Include(i => i.Buildings)
                    .Where(i => i.Buildings.Id == buildingId && i.BuildingId == buildingId);
                return stores.ToList();
            }
        }
        public List<Store> GetListWtihBuilding()
        {
            using (var context = new BuildAppYDContext())
            {
                return context.Stores.Include(i => i.Buildings).ToList();
            }
        }
    }
}
