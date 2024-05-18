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
        public Task<User> createUser(User user);
        public Task<User> updateUser(User user);
        public Task<int> deleteUser(int userId);
        public Task<User> getUserById(int userId);
        public Task<IEnumerable<User>> getUsers();
        public Task<bool> checkExitsName(string name);
    }
}
