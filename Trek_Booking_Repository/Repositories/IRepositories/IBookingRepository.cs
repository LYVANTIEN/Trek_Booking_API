using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trek_Booking_DataAccess;

namespace Trek_Booking_Repository.Repositories.IRepositories
{
    public interface IBookingRepository
    {
        public Task<IEnumerable<Booking>> getBookingbyUserId(int userId);
        public Task<IEnumerable<Booking>> getBookingbyHotelId(int hotelId);
        public Task<IEnumerable<Booking>> getBookingbyRoomId(int roomId);
        public Task<Booking> getBookingbyId(int bookingId);
        public Task<Booking> deleteBooking(Booking booking);
        public Task<Booking> createBooking(Booking booking);
        public Task<bool> checkBookingExists(int userId, int roomId);
        public Task<IEnumerable<Booking>> getBookings();
    }
}
