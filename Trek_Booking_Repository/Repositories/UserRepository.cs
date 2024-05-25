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
        private readonly IPasswordHasher _passwordHasher;

        public UserRepository(ApplicationDBContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

<<<<<<< HEAD
        public async Task<bool> checkExitsEmail(string email)
        {
=======
        public async Task<User> checkBannedUser(User user)
        {
            var userStatus = await _context.users.FirstOrDefaultAsync(u => u.Status == user.Status);
            return userStatus;
        }

        public async Task<User> getUserByEmail(string email)
        {
            var existingUser = await _context.users.FirstOrDefaultAsync(u => u.Email == email);
            return existingUser;
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
        public async Task<bool> checkExitsEmail(string email)
        {
>>>>>>> d545ad44f83c7ab32db21c7918cb89b5486b6c81
            var check = await _context.users.AnyAsync(u => u.Email == email);
            return check;
        }

        public async Task<User> createUser(User registerRequest)
        {
            var existingUser = await getUserByEmail(registerRequest.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists.");
            }
            var passwordHash = _passwordHasher.HashPassword(registerRequest.Password);

            // Add the new user to the database
            var user = new User
            {
                UserName = registerRequest.UserName,
                Email = registerRequest.Email,
                Password = passwordHash,
                Address = registerRequest.Address,
                Phone = registerRequest.Phone,
                Status = true,
                IsVerify = true,
                RoleId = registerRequest.RoleId,
            };
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
