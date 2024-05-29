using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trek_Booking_DataAccess;
using Trek_Booking_Hotel_3D_API.Service;
using Trek_Booking_Repository.Repositories;
using Trek_Booking_Repository.Repositories.IRepositories;

namespace Trek_Booking_Hotel_3D_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IAuthenticationUserRepository _authenticationUserRepository;
        private readonly IJwtUtils _jwtUtils;


        public UserAPIController(IUserRepository repository, IAuthenticationUserRepository authenticationUserRepository,
            IJwtUtils jwtUtils)
        {
            _repository = repository;
            _authenticationUserRepository = authenticationUserRepository;
            _jwtUtils = jwtUtils;
        }
        [HttpGet("/getUsers")]
        public async Task<IActionResult> getUsers()
        {
            var c = await _repository.getUsers();
            if (c == null)
            {
                return NotFound("Not Found");
            }
            return Ok(c);
        }
        [HttpGet("/getUserById/{userId}")]
        public async Task<IActionResult> getUserById(int userId)
        {
            var check = await _repository.getUserById(userId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }

        [HttpGet("/getUserByRoleId/{roleId}")]
        public async Task<IActionResult> getUserByRoleId(int roleId)
        {
            var check = await _repository.getUserByRoleId(roleId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }

        [HttpPost("/createUser")]
        public async Task<IActionResult> createUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            else if (await _repository.checkExitsEmail(user.Email))
            {
                return BadRequest("Email already exits");
            }
            var create = await _repository.createUser(user);
            return StatusCode(201, "Create Successfully!");
        }

        [HttpPut("/deleteUser/{userId}")]
        public async Task<IActionResult> deleteUser(int userId)
        {
            var check = await _repository.getUserById(userId);
            if (check == null)
            {
                return NotFound("Not found User");
            }
            await _repository.deleteUser(userId);
            return StatusCode(200, "Delele Successfully!");
        }
        [HttpPut("/recoverUserDeleted/{userId}")]
        public async Task<IActionResult> recoverUserDeleted(int userId)
        {
            var check = await _repository.getUserById(userId);
            if (check == null)
            {
                return NotFound("Not found User");
            }
            await _repository.recoverUserDeleted(userId);
            return StatusCode(200, "Recover Successfully!");
        }
        [HttpPost("/loginClient")]
        public async Task<IActionResult> loginClient([FromBody] User user)
        {
            if (user == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _authenticationUserRepository.checkPasswordClient(user);
            if (result != null)
            {
                var checkBanned = await _repository.checkBannedUser(result);
                if (checkBanned.Status == false)
                {
                    return BadRequest("The account of user is banned!");
                }
                var token = _jwtUtils.GenerateTokenClient(result);
                return Ok(new UserResponse()
                {
                    IsAuthSuccessful = true,
                    ToKen = token,
                    User = new User()
                    {
                        UserName = result.UserName,
                        UserId = result.UserId,
                        Email = result.Email,
                        Phone = result.Phone,
                        RoleId = result.RoleId,
                    },
                    RoleId = result.RoleId
                });
            }
            else
            {
                return Unauthorized(new UserResponse
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = "Email or password is not correct!"
                });
            }
            return StatusCode(200);
        }
        [HttpPost("/registerClient")]
        public async Task<IActionResult> RegisterClient([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _repository.createUser(user);
            return StatusCode(200);
        }

        [HttpPut("ToggleUser")]
        public async Task<IActionResult> ToggleStatus([FromBody] ToggleUserRequest request)
        {
            return await _repository.ToggleStatus(request);
        }
    }
}
