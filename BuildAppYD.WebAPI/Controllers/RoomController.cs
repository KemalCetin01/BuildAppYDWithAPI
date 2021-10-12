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
    public class RoomController : ControllerBase
    {
        private IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("getListRoom")]
        public IActionResult getListRoom()
        {
            var result = _roomService.getList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public IActionResult getById(int id)
        {
            var result = _roomService.getById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }

        [HttpGet("getByBuildingId")]
        public  IActionResult getByBuildingId(int buildingId)
        {
            var result = _roomService.getListByBuildingId(buildingId);
            
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetListWtihBuilding")]
        public  IActionResult GetListWtihBuilding()
        {
            var result = _roomService.GetListWtihBuilding();
            
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("AddRoom")]
        public IActionResult AddRoom(Room room)
        {
            var result = _roomService.Add(room);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPut("UpdateRoom")]
        public IActionResult UpdateRoom(Room room)
        {
            var result = _roomService.Update(room);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("DeleteRoom")]
        public IActionResult DeleteRoom(int id)
        {
            var removeRoom = _roomService.getById(id);
            if (removeRoom.Success)
            {
                var result = _roomService.Delete(removeRoom.Data);
                if (result.Success)
                {
                    return Ok(result.Message);
                }

                return BadRequest(result.Message);
            }

            return BadRequest(removeRoom.Message);
        }
    }
}
