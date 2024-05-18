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
        public Task<IEnumerable<Booking>> getBookingByUserId(int userId);
        public Task<IEnumerable<Booking>> getBookingByHotelId(int hotelId);
        public Task<IEnumerable<Booking>> getBookingByRoomId(int roomId);
        public Task<Booking> getBookingById(int bookingId);
        public Task<Booking> deleteBooking(Booking booking);
        public Task<Booking> createBooking(Booking booking);
        public Task<bool> checkBookingExists(int userId, int roomId);
        public Task<IEnumerable<Booking>> getBookings();
    }
}
