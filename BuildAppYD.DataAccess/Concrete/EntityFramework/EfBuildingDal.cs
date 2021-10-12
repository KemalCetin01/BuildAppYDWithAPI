using BuildAppYD.Core.DataAccess.EntityFramework;
using BuildAppYD.DataAccess.Concrete.EntityFramework.Contexts;
using BuildAppYD.DataAccess.Service;
using BuildAppYD.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAppYD.DataAccess.Concrete.EntityFramework
{
    public class EfBuildingDal : EfEntityRepositoryBase<Building, BuildAppYDContext>, IBuildingDal
    {
        public Building getDetail(int id)
        {
            using (var context = new BuildAppYDContext())
            {
                return context.Buildings
                      .Include(i=>i.Rooms)
                      .Include(i=>i.Stores)
                      .Where(i => i.Id == id).FirstOrDefault();
            }
        }
    }
}
