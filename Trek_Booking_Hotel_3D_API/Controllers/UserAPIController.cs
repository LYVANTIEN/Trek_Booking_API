using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trek_Booking_DataAccess;
using Trek_Booking_Repository.Repositories.IRepositories;

namespace Trek_Booking_Hotel_3D_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserAPIController(IUserRepository repository)
        {
            _repository = repository;
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
    }
}
