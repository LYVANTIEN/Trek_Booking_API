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
    public class AuthenticationUserRepository : IAuthenticationUserRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;

        public AuthenticationUserRepository(ApplicationDBContext context, IPasswordHasher passwordHasher,
            IUserRepository userRepository) 
        { 
            _context = context;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }
        public async Task<User> checkPassword(User loginRequest)
        {
            var user = await _userRepository.getUserByEmail(loginRequest.Email);
            if (user == null)
            {
                throw new Exception("Email is not found!");
            }
            var result = _passwordHasher.Verify(user.Password, loginRequest.Password);
            if (!result)
            {
                throw new Exception("Email or password is not correct!");
            }
            return user;
        }
    }
}
