using System;
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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> checkExitsName(string name)
        {
            var check = await _context.users.AnyAsync(n => n.UserName == name);
            return check;
        }

        public async Task<User> createUser(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<int> deleteUser(int userId)
        {
            var deleteUser = await _context.users.FirstOrDefaultAsync(t => t.UserId == userId);
            if (deleteUser != null)
            {
                _context.users.Remove(deleteUser);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<User> getUserById(int userId)
        {
            var getUser = await _context.users.FirstOrDefaultAsync(t => t.UserId == userId);
            return getUser;
        }

        public async Task<IEnumerable<User>> getUsers()
        {
            var users = await _context.users.ToListAsync();
            return users;
        }

        public async Task<User> updateUser(User user)
        {
            var findUser = await _context.users.FirstOrDefaultAsync(t => t.UserId == user.UserId);
            if (findUser != null)
            {
                findUser.UserName = user.UserName;
                findUser.Email = user.Email;
                findUser.Phone = user.Phone;
                findUser.Address = user.Address;
                findUser.Password = user.Password;
                findUser.Status = user.Status;
                findUser.IsVerify = user.IsVerify;
                _context.users.Update(findUser);
                await _context.SaveChangesAsync();
                return findUser;
            }
            return null;
        }
    }
}
