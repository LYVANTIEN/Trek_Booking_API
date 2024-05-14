using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trek_Booking_DataAccess;
using Trek_Booking_Repository.Repositories.IRepositories;

namespace Trek_Booking_Hotel_3D_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAPIController : ControllerBase
    {
        private readonly IRoomRepository _repository;

        public RoomAPIController(IRoomRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("/getRooms")]
        public async Task<IActionResult> getRooms()
        {
            var c = await _repository.getRooms();
            if (c == null)
            {
                return NotFound("Not Found");
            }
            return Ok(c);
        }
        [HttpGet("/getRoomById/{roomId}")]
        public async Task<IActionResult> getRoomById(int roomId)
        {
            var check = await _repository.getRoomById(roomId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }

        [HttpGet("/getRoomByHotelId/{hotelId}")]
        public async Task<IActionResult> getRoomByHotelId(int hotelId)
        {
            var check = await _repository.getRoomByHotelId(hotelId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }

        [HttpPost("/createRoom")]
        public async Task<IActionResult> createRoom([FromBody] Room room)
        {
            if (room == null)
            {
                return BadRequest();
            }
            else if (await _repository.checkExitsName(room.RoomName))
            {
                return BadRequest("RoomName already exits");
            }
            var create = await _repository.createRoom(room);
            return StatusCode(201, "Create Successfully!");
        }
        [HttpPut("/updateRoom")]
        public async Task<IActionResult> updateRoom([FromBody] Room room)
        {
            var check = await _repository.getRoomById(room.RoomId);
            if (check == null)
            {
                return BadRequest("Not found Room");
            }
            var update = await _repository.updateRoom(room);
            return Ok(update);
        }
        [HttpDelete("/deleteRoom/{roomId}")]
        public async Task<IActionResult> deleteRoom(int roomId)
        {
            var check = await _repository.getRoomById(roomId);
            if (check == null)
            {
                return NotFound("Not found Hotel");
            }
            await _repository.deleteRoom(roomId);
            return StatusCode(200, "Delele Successfully!");
        }
    }
}
