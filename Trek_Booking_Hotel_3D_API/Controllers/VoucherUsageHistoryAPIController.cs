using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trek_Booking_DataAccess;
using Trek_Booking_Repository.Repositories.IRepositories;

namespace Trek_Booking_Hotel_3D_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherUsageHistoryAPIController : ControllerBase
    {
        private readonly IVoucherUsageHistoryRepository _repository;

        public VoucherUsageHistoryAPIController(IVoucherUsageHistoryRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("/getVoucherUsageHistories")]
        public async Task<IActionResult> getVoucherUsageHistories()
        {
            var c = await _repository.getVoucherUsageHistories();
            if (c == null)
            {
                return NotFound("Not Found");
            }
            return Ok(c);
        }
        [HttpGet("/getVoucherUsageHistoryById/{UserVoucherId}")]
        public async Task<IActionResult> getVoucherUsageHistoryById(int UserVoucherId)
        {
            var check = await _repository.getVoucherUsageHistoryById(UserVoucherId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }
        [HttpPost("/createVoucherUsageHistory")]
        public async Task<IActionResult> createVoucherUsageHistory([FromBody] VoucherUsageHistory voucherUsageHistory)
        {
            if (voucherUsageHistory == null)
            {
                return BadRequest();
            }
            var create = await _repository.createVoucherUsageHistory(voucherUsageHistory);
            return StatusCode(201, "Create Successfully!");
        }
        [HttpGet("/getVoucherUsageHistoryByUserId/{userId}")]
        public async Task<IActionResult> getVoucherUsageHistoryByUserId(int userId)
        {
            var check = await _repository.getVoucherUsageHistoryByUserId(userId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }
    }
}
