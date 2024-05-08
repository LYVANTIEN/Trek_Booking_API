using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trek_Booking_DataAccess;

namespace Trek_Booking_Repository.Repositories.IRepositories
{
    public interface IHotelRepository
    {
        public Task<Hotel> CreateHotel(Hotel hotel); 
        public Task<Hotel> UpdateHotel(Hotel hotel); 
        public Task<int> DeleteHotel(int HotelId); 
        public Task<Hotel> GetHotelbyId(int hotelId);
        public Task<IEnumerable<Hotel>> GetHotels();

        public Task<bool> CheckExitsName(string name);

    }
}
