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

        public async Task<bool> checkExitsEmail(string email)
        {
            var check = await _context.users.AnyAsync(u => u.Email == email);
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
                deleteUser.Status = false;
                _context.users.Update(deleteUser);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<User> getUserById(int userId)
        {
            var getUser = await _context.users.FirstOrDefaultAsync(t => t.UserId == userId);
            return getUser;
        }

        public async Task<IEnumerable<User>> getUserByRoleId(int roleId)
        {
            var get = await _context.users.Where(t => t.RoleId == roleId).ToListAsync();
            if (get.Any())
            {
                return get;
            }
            throw new Exception("Not found");
        }

        public async Task<IEnumerable<User>> getUsers()
        {
            var users = await _context.users.ToListAsync();
            return users;
        }

        public async Task<int> recoverUserDeleted(int userId)
        {
            var deleteUser = await _context.users.FirstOrDefaultAsync(t => t.UserId == userId);
            if (deleteUser != null)
            {
                deleteUser.Status = true;
                _context.users.Update(deleteUser);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
