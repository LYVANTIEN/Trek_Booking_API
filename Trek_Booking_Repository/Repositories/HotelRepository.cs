using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trek_Booking_DataAccess;
using Trek_Booking_DataAccess.Data;
using Trek_Booking_Repository.Repositories.IRepositories;

namespace Trek_Booking_Repository.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDBContext _context;

        public HotelRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> checkExitsEmail(string email)
        {
            var check = await _context.hotels.AnyAsync(t => t.HotelEmail == email);
            return check;
        }

        public async Task<bool> checkExitsName(string name)
        {
            var check = await _context.hotels.AnyAsync(n => n.HotelName == name);
            return check;
        }

        public async Task<Hotel> createHotel(Hotel hotel)
        {
            hotel.IsVerify = true;
            _context.hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<int> deleteHotel(int hotelId)
        {
            var deleteHotel = await _context.hotels.FirstOrDefaultAsync(t => t.HotelId == hotelId);
            if (deleteHotel != null)
            {
                deleteHotel.IsVerify = false;
                _context.hotels.Update(deleteHotel);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Hotel> getHotelbyId(int hotelId)
        {
            var getHotel = await _context.hotels.FirstOrDefaultAsync(t => t.HotelId == hotelId);
            return getHotel;
        }

        public async Task<IEnumerable<Hotel>> getHotels()
        {
            var hotels = await _context.hotels.Include(s => s.Supplier).ToListAsync();
            return hotels;
        }
        public async Task<IEnumerable<Hotel>> getHotelsBySupplierId(int supplierId)
        {
            var hotelsBySupp = await _context.hotels.Where(s => s.SupplierId == supplierId).ToListAsync();
            return hotelsBySupp;
        }

        public async Task<int> recoverHotelDeleted(int hotelId)
        {
            var deleteHotel = await _context.hotels.FirstOrDefaultAsync(t => t.HotelId == hotelId);
            if (deleteHotel != null)
            {
                deleteHotel.IsVerify = true;
                _context.hotels.Update(deleteHotel);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<Hotel>> searchHotelByName(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Search key cannot be null or empty", nameof(key));
            }

            var hotels = await _context.hotels.ToListAsync();

            var result = hotels.Where(h => h.HotelName.Contains(key, StringComparison.OrdinalIgnoreCase));
            return result;
        }

        public async Task<Hotel> updateHotel(Hotel hotel)
        {
            var findHotel = await _context.hotels.FirstOrDefaultAsync(t => t.HotelId == hotel.HotelId);
            if (findHotel != null)
            {
                findHotel.HotelName = hotel.HotelName;
                findHotel.HotelPhone = hotel.HotelPhone;
                findHotel.HotelEmail = hotel.HotelEmail;
                findHotel.HotelAvatar = hotel.HotelAvatar;
                findHotel.HotelFulDescription = hotel.HotelFulDescription;
                findHotel.HotelDistrict = hotel.HotelDistrict;
                findHotel.HotelCity = hotel.HotelCity;
                findHotel.HotelInformation = hotel.HotelInformation;
                findHotel.SupplierId = hotel.SupplierId;
                _context.hotels.Update(findHotel);
                await _context.SaveChangesAsync();
                return findHotel;
            }
            return null;
        }

        public async Task<Hotel> updateHotelAvatar(Hotel hotel)
        {
            var findHotel = await _context.hotels.FirstOrDefaultAsync(t => t.HotelId == hotel.HotelId);
            if (findHotel != null)
            {
                // Kiểm tra xem SupplierId có hợp lệ hay không
                var supplierExists = await _context.suppliers.AnyAsync(s => s.SupplierId == findHotel.SupplierId);
                if (!supplierExists)
                {
                    throw new InvalidOperationException("Invalid SupplierId.");
                }

                // Cập nhật trường HotelAvatar
                findHotel.HotelAvatar = hotel.HotelAvatar;

                // Giữ nguyên các giá trị khác
                findHotel.HotelName = findHotel.HotelName;
                findHotel.HotelPhone = findHotel.HotelPhone;
                findHotel.HotelEmail = findHotel.HotelEmail;
                findHotel.HotelFulDescription = findHotel.HotelFulDescription;
                findHotel.HotelDistrict = findHotel.HotelDistrict;
                findHotel.HotelCity = findHotel.HotelCity;
                findHotel.HotelInformation = findHotel.HotelInformation;
                findHotel.SupplierId = findHotel.SupplierId;

                // Chỉ cập nhật trường HotelAvatar
                _context.hotels.Update(findHotel);
                await _context.SaveChangesAsync();
                return findHotel;
            }
            return null;
        }






    }
}
