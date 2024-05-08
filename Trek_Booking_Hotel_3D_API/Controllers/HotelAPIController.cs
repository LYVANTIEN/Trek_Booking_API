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
        [HttpGet("/GetHotels")]
        public async Task<IActionResult> GetHotels()
        {
            var c = await _repository.GetHotels();
            if (c == null)
            {
                return NotFound("Not Found");
            }
            return Ok(c);
        }
        [HttpGet("/GetHotelbyId/{hotelId}")]
        public async Task<IActionResult> GetHotelbyId(int hotelId)
        {
            var check = await _repository.GetHotelbyId(hotelId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }
        [HttpPost("/CreateHotel")]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            if (hotel == null)
            {
                return BadRequest();
            }
            else if (await _repository.CheckExitsName(hotel.HotelName))
            {
                return BadRequest("HotelName already exits");
            }
            var create = await _repository.CreateHotel(hotel);
            return StatusCode(201, "Create Successfully!");
        }
        [HttpPut("/UpdateHotel")]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotel hotel)
        {
            var check = await _repository.GetHotelbyId(hotel.HotelId);
            if (check == null)
            {
                return BadRequest("Not found Hotel");
            }
            var update = await _repository.UpdateHotel(hotel);
            return Ok(update);
        }
        [HttpDelete("/DeleteHotel/{hotelId}")]
        public async Task<IActionResult> DeleteHotel(int hotelId)
        {
            var check = await _repository.GetHotelbyId(hotelId);
            if (check == null)
            {
                return NotFound("Not found Hotel");
            }
            await _repository.DeleteHotel(hotelId);
            return StatusCode(200, "Delele Successfully!");
        }
    }
}
