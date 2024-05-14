using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trek_Booking_DataAccess;

namespace Trek_Booking_Repository.Repositories.IRepositories
{
    public interface IBookingCartRepository
    {
        public Task<IEnumerable<BookingCart>> getBookingCartByUserId(int userId);
        public Task<IEnumerable<BookingCart>> getBookingCartByHotelId(int hotelId);
        public Task<IEnumerable<BookingCart>> getBookingCartByRoomId(int roomId);
        public Task<BookingCart> getBookingCartById(int bookingCartId);
        public Task<int> deleteBookingCart(int bookingCartId);
        public Task<BookingCart> createBookingCart(BookingCart bookingCart);
        public Task<bool> checkBookingCartExists(int userId, int roomId);
        public Task<BookingCart> updateBookingCart(BookingCart bookingCart);
        public Task<IEnumerable<BookingCart>> getBookingCarts();
    }
}
