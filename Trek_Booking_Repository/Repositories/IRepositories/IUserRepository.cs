using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trek_Booking_DataAccess;

namespace Trek_Booking_Repository.Repositories.IRepositories
{
    public interface IUserRepository
    {
<<<<<<< HEAD
        public Task<User> createUser(User user);
        public Task<int> deleteUser(int userId);
        public Task<int> recoverUserDeleted(int userId);
        public Task<User> getUserById(int userId);
        public Task<IEnumerable<User>> getUsers();
        public Task<IEnumerable<User>> getUserByRoleId(int roleId);
        public Task<bool> checkExitsEmail(string email);
=======

        public Task<User> createUser(User registerRequest);
        public Task<User> updateUser(User user);
        public Task<int> deleteUser(int userId);
        public Task<int> recoverUserDeleted(int userId);
        public Task<IEnumerable<User>> getUserByRoleId(int roleId);
        public Task<bool> checkExitsEmail(string email);
        public Task<User> getUserById(int userId);
        public Task<IEnumerable<User>> getUsers();
        public Task<User> getUserByEmail(string email);
        public Task<User> checkBannedUser(User user);

>>>>>>> d545ad44f83c7ab32db21c7918cb89b5486b6c81
    }
}
