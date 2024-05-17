﻿using Azure.Core;
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

        public async Task<int> deleteHotel(int HotelId)
        {
            var deleteHotel = await _context.hotels.FirstOrDefaultAsync(t => t.HotelId == HotelId);
            if (deleteHotel != null)
            {
                _context.hotels.Remove(deleteHotel);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Hotel> getHotelById(int hotelId)
        {
            var getHotel = await _context.hotels.FirstOrDefaultAsync(t => t.HotelId == hotelId);
            return getHotel;
        }

        public async Task<IEnumerable<Hotel>> getHotelBySupplierId(int supplierId)
        {
            var c = await _context.hotels.Where(t => t.SupplierId == supplierId).ToListAsync();
            if (c.Any())
            {
                return c;
            }
            return null;
        }

        public async Task<IEnumerable<Hotel>> getHotels()
        {
            var hotels = await _context.hotels.Include(s => s.Supplier).ToListAsync();
            return hotels;
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
    }
}
