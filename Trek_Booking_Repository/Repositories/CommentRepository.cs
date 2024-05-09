using Microsoft.EntityFrameworkCore;
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
    public class CommentRepository :ICommentRepository
    {
        private readonly ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<Comment> createComment(Comment comment)
        {
            throw new NotImplementedException();
        }




        //public async Task<Comment> CreateComment(Comment comment)
        //{
        //    var checkBooked = await _context.bookings.FirstOrDefault(b => b.BookingId == comment.BookingId);
        //    _context.hotels.Add(hotel);
        //    await _context.SaveChangesAsync();
        //    return hotel;
        //}


        public async Task<IEnumerable<Comment>> getCommentByHotelId(int hotelId)
        {
            //var getHotel = await _context.hotels.FirstOrDefaultAsync(t => t.HotelId == hotelId);
            //var comments = await _context.comments.Where(c => c.Hotel == getHotel).ToListAsync();
            var comments = await _context.comments.Where(t => t.HotelId == hotelId).ToListAsync();

            return comments;
        }


        public async Task<IEnumerable<Comment>> getCommentByUserId(int userId)
        {
            var comments = await _context.comments.Where(t => t.UserId == userId).ToListAsync();
            return comments;
        }

    }
}
