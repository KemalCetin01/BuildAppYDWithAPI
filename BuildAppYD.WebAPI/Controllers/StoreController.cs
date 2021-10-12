using BuildAppYD.Business.Service;
using BuildAppYD.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BuildAppYD.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet("getListStore")]
        public IActionResult getListStore()
        {
            var result = _storeService.getList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetListWtihBuilding")]
        public IActionResult GetListWtihBuilding()
        {
            var result = _storeService.GetListWtihBuilding();

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getByBuildingId")]
        public IActionResult getByBuildingId(int buildingId)
        {
            var result = _storeService.getListByBuildingId(buildingId);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getById")]
        public IActionResult getById(int id)
        {
            var result = _storeService.getById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpPost("AddStore")]
        public IActionResult AddStore(Store store)
        {
            var result = _storeService.Add(store);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPut("UpdateStore")]
        public IActionResult UpdateStore(Store store)
        {
            var result = _storeService.Update(store);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("DeleteStore")]
        public IActionResult DeleteStore(int id)
        {
            var removeStore = _storeService.getById(id);
            if (removeStore.Success)
            {
                var result = _storeService.Delete(removeStore.Data);
                if (result.Success)
                {
                    return Ok(result.Message);
                }

                return BadRequest(result.Message);
            }

            return BadRequest(removeStore.Message);
        }
    }
}

