using BuildAppYD.Business.Service;
using BuildAppYD.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildAppYD.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuildingController : ControllerBase
    {
        private IBuildingService _buildingService;
        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        [HttpGet("getList")]
        public IActionResult getList()
        {
            var result = _buildingService.getList();

                return Ok(result);
            
        }

        [HttpGet("getDetail")]
        public IActionResult getDetail(int id)
        {
            var result = _buildingService.getDetail(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);

        }

        [HttpPost("Add")]
        public IActionResult Add(Building building)
        {
            var result = _buildingService.Add(building);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPut("Update")]
        public IActionResult Update(Building building)
        {
            var result = _buildingService.Update(building);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var removeBuilding = _buildingService.getDetail(id);
            if (removeBuilding.Success)
            {
                var result = _buildingService.Delete(removeBuilding.Data);
                if (result.Success)
                {
                    return Ok(result.Message);
                }

                return BadRequest(result.Message);

            }

            return BadRequest(removeBuilding.Message);
        }
    }
}
