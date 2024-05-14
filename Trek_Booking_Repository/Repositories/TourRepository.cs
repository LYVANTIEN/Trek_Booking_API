﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trek_Booking_DataAccess.Data;
using Trek_Booking_DataAccess;
using Trek_Booking_Repository.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Trek_Booking_Repository.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly ApplicationDBContext _context;
        public TourRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> checkExitsName(string name)
        {
            var check = await _context.tours.AnyAsync(n => n.TourName == name);
            return check;
        }

        public async Task<Tour> createTour(Tour tour)
        {
            _context.tours.Add(tour);
            await _context.SaveChangesAsync();
            return tour;
        }

        public async Task<int> deleteTour(int tourId)
        {
            var deleteTour = await _context.tours.FirstOrDefaultAsync(t => t.TourId == tourId);
            if (deleteTour != null)
            {
                _context.tours.Remove(deleteTour);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Tour> getTourById(int tourId)
        {
            var getTour = await _context.tours.FirstOrDefaultAsync(t => t.TourId == tourId);
            return getTour;
        }

        public async Task<IEnumerable<Tour>> getTours()
        {
            var tours = await _context.tours.ToListAsync();
            return tours;
        }

        public async Task<Tour> updateTour(Tour tour)
        {
            var findTour = await _context.tours.FirstOrDefaultAsync(t => t.TourId == tour.TourId);
            if (findTour != null)
            {
                findTour.TourName = tour.TourName;
                findTour.TourDescription = tour.TourDescription;
                findTour.TourPrice = tour.TourPrice;
                findTour.TourAddress = tour.TourAddress;
                findTour.TourTime = tour.TourTime;
                findTour.TourTransportation = tour.TourTransportation;
                findTour.TourCapacity = tour.TourCapacity;
                _context.tours.Update(findTour);
                await _context.SaveChangesAsync();
                return findTour;
            }
            return null;
        }
    }
}