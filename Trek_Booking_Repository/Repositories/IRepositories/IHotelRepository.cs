using Trek_Booking_DataAccess;

namespace Trek_Booking_Repository.Repositories.IRepositories
{
    public interface IHotelRepository
    {
        public Task<Hotel> createHotel(Hotel hotel);
        public Task<Hotel> updateHotel(Hotel hotel);
        public Task<int> deleteHotel(int hotelId);
        public Task<int> recoverHotelDeleted(int hotelId);
        public Task<Hotel> getHotelbyId(int hotelId);
        public Task<IEnumerable<Hotel>> getHotels();
        public Task<IEnumerable<Hotel>> getHotelsBySupplierId(int supplierId);
        public Task<bool> checkExitsName(string name);
        public Task<bool> checkExitsEmail(string email);
        public Task<IEnumerable<Hotel>> searchHotelByName(string key);
<<<<<<< HEAD

=======
>>>>>>> d545ad44f83c7ab32db21c7918cb89b5486b6c81

    }
}
