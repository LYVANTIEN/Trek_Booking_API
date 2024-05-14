using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trek_Booking_DataAccess;
using Trek_Booking_Repository.Repositories.IRepositories;

namespace Trek_Booking_Hotel_3D_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingCartAPIController : ControllerBase
    {
        private readonly IBookingCartRepository _repository;

        public BookingCartAPIController(IBookingCartRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/getBookingCarts")]
        public async Task<IActionResult> getBookingCarts()
        {
            var c = await _repository.getBookingCarts();
            return Ok(c);
        }

        [HttpGet("/getBookingCartById/{bookingCartId}")]
        public async Task<IActionResult> getBookingCartById(int bookingCartId)
        {
            var check = await _repository.getBookingCartById(bookingCartId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }

        [HttpGet("/getBookingCartByUserId/{userId}")]
        public async Task<IActionResult> getBookingCartByUserId(int userId)
        {
            var check = await _repository.getBookingCartByUserId(userId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }

        [HttpGet("/getBookingCartByHotelId/{hotelId}")]
        public async Task<IActionResult> getBookingCartByHotelId(int hotelId)
        {
            var check = await _repository.getBookingCartByHotelId(hotelId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }

        [HttpGet("/getBookingCartByRoomId/{roomId}")]
        public async Task<IActionResult> getBookingCartByRoomId(int roomId)
        {
            var check = await _repository.getBookingCartByRoomId(roomId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }

        [HttpPost("/createBookingCart")]
        public async Task<IActionResult> createBookingCart([FromBody] BookingCart bookingCart)
        {
            try
            {
                var bookingCartExists = await _repository.checkBookingCartExists(bookingCart.UserId, bookingCart.RoomId);
                if (bookingCartExists)
                {
                    return BadRequest("BookingCart already exists for the specified userId and roomId");
                }

                await _repository.createBookingCart(bookingCart);
                return StatusCode(201, "Create Successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest("User or Room not exits");
            }
        }

        [HttpPut("/updateBookingCart")]
        public async Task<IActionResult> updateBookingCart([FromBody] BookingCart bookingCart)
        {
            var checkCart = await _repository.getBookingCartById(bookingCart.BookingCartId);
            if (checkCart == null)
            {
                return BadRequest("BookingCart is not exits");
            }

            await _repository.updateBookingCart(bookingCart);
            return StatusCode(200, "Update Successfully!");
        }


        [HttpDelete("/deleteBookingCart/{bookingCartId}")]
        public async Task<IActionResult> deleteBookingCart(int bookingCartId)
        {
            var check = await _repository.getBookingCartById(bookingCartId);
            if (check == null)
            {
                return BadRequest("null empty or error input");
            }
            await _repository.deleteBookingCart(bookingCartId);
            return StatusCode(200, "Delele Successfully!");

        }
    }
}
