using FurniStyle.Core.IServices.Furnis;
using FurniStyle.Core.IServices.Rooms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FurniStyle.API.Controllers.Room
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet("AllRooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            var result = await _roomService.GetAllRoomsAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int? id)
        {
            if (id == null) BadRequest("Invalid Id");
            var product = await _roomService.GetRoomByIdAsync(id.Value);
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}
