using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trek_Booking_DataAccess;
using Trek_Booking_Repository.Repositories.IRepositories;

namespace Trek_Booking_Hotel_3D_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingAPIController : ControllerBase
    {
        private readonly IBookingRepository _repository;

        public BookingAPIController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/getBookings")]
        public async Task<IActionResult> getBookings()
        {
            var c = await _repository.getBookings();
            return Ok(c);
        }

        [HttpGet("/getBookingbyId/{bookingId}")]
        public async Task<IActionResult> getBookingbyId(int bookingId)
        {
            var check = await _repository.getBookingbyId(bookingId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }

        [HttpGet("/getBookingbyUserId/{userId}")]
        public async Task<IActionResult> getBookingbyUserId(int userId)
        {
            var check = await _repository.getBookingbyUserId(userId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }

        [HttpGet("/getBookingbyHotelId/{hotelId}")]
        public async Task<IActionResult> getBookingbyHotelId(int hotelId)
        {
            var check = await _repository.getBookingbyHotelId(hotelId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }

        [HttpGet("/getBookingbyRoomId/{roomId}")]
        public async Task<IActionResult> getBookingbyRoomId(int roomId)
        {
            var check = await _repository.getBookingbyRoomId(roomId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }

        [HttpPost("/createBooking")]
        public async Task<IActionResult> createBooking([FromBody] Booking booking)
        {
            try
            {
                var bookingCartExists = await _repository.checkBookingExists(booking.UserId, booking.RoomId);
                if (bookingCartExists)
                {
                    return BadRequest("BookingCart already exists for the specified userId and roomId");
                }

                await _repository.createBooking(booking);
                return StatusCode(201, "Create Successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest("User or Room not exits");
            }
        }

        [HttpPut("/deleteBooking")]
        public async Task<IActionResult> deleteBooking(Booking booking)
        {
            var checkCart = await _repository.getBookingbyId(booking.BookingId);
            if (checkCart == null)
            {
                return BadRequest("Booking is not exits");
            }

            await _repository.deleteBooking(booking);
            return StatusCode(200, "Delete Successfully!");
        }
    }
}
