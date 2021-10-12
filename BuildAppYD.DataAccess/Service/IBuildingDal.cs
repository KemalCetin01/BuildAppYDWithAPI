using BuildAppYD.Core.DataAccess;
using BuildAppYD.Core.Utilities.Results;
using BuildAppYD.Entities.DTOs;

namespace BuildAppYD.DataAccess.Service
{
   public interface IBuildingDal: IEntityRepository<Building>
    {
        Building getDetail(int id);
        
    }
}
