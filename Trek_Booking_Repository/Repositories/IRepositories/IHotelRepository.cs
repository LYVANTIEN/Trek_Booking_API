using Trek_Booking_DataAccess;

namespace Trek_Booking_Repository.Repositories.IRepositories
{
    public interface IHotelRepository
    {
        public Task<Hotel> createHotel(Hotel hotel);
        public Task<Hotel> updateHotel(Hotel hotel);
        public Task<int> deleteHotel(int HotelId);
        public Task<Hotel> getHotelById(int hotelId);
        public Task<IEnumerable<Hotel>> getHotels();

        public Task<bool> checkExitsName(string name);

    }
}
