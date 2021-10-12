using BuildAppYD.Core.Utilities.Results;
using BuildAppYD.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAppYD.Business.Service
{
    public interface IBuildingService
    {
        IEnumerable<Building> getList();
        IDataResult<Building> getById(int Id);
        IResult Add(Building building);
        IResult Delete(Building building);
        IResult Update(Building building);
        IDataResult<Building> getDetail(int buildingId);
    }
}
