using Trek_Booking_DataAccess;

namespace Trek_Booking_Repository.Repositories.IRepositories
{
    public interface IHotelRepository
    {
        public Task<Hotel> createHotel(Hotel hotel);
        public Task<Hotel> updateHotel(Hotel hotel);
        public Task<int> deleteHotel(int HotelId);
        public Task<Hotel> getHotelbyId(int hotelId);
        public Task<IEnumerable<Hotel>> getHotels();
        public Task<IEnumerable<Hotel>> getHotelsBySupplierId (int supplierId);

        public Task<bool> checkExitsName(string name);

    }
}
