using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Trek_Booking_DataAccess;
using Trek_Booking_Repository.Repositories.IRepositories;

namespace Trek_Booking_Hotel_3D_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelAPIController : ControllerBase
    {
        private readonly IHotelRepository _repository;

        public HotelAPIController(IHotelRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("/getHotels")]
        public async Task<IActionResult> getHotels()
        {
            var c = await _repository.getHotels();
            if (c == null)
            {
                return NotFound("Not Found");
            }
            return Ok(c);
        }
        [HttpGet("/getHotelById/{hotelId}")]
        public async Task<IActionResult> getHotelById(int hotelId)
        {
            var check = await _repository.getHotelById(hotelId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }
        [HttpPost("/createHotel")]
        public async Task<IActionResult> createHotel([FromBody] Hotel hotel)
        {
            if (hotel == null)
            {
                return BadRequest();
            }
            else if (await _repository.checkExitsName(hotel.HotelName))
            {
                return BadRequest("HotelName already exits");
            }
            var create = await _repository.createHotel(hotel);
            return StatusCode(201, "Create Successfully!");
        }
        [HttpPut("/updateHotel")]
        public async Task<IActionResult> updateHotel([FromBody] Hotel hotel)
        {
            var check = await _repository.getHotelById(hotel.HotelId);
            if (check == null)
            {
                return BadRequest("Not found Hotel");
            }
            var update = await _repository.updateHotel(hotel);
            return Ok(update);
        }
        [HttpDelete("/deleteHotel/{hotelId}")]
        public async Task<IActionResult> deleteHotel(int hotelId)
        {
            var check = await _repository.getHotelById(hotelId);
            if (check == null)
            {
                return NotFound("Not found Hotel");
            }
            await _repository.deleteHotel(hotelId);
            return StatusCode(200, "Delele Successfully!");
        }
    }
}
