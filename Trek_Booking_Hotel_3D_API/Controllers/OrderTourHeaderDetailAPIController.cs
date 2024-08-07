﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trek_Booking_Hotel_3D_API.Helper;
using Trek_Booking_Repository.Repositories.IRepositories;

namespace Trek_Booking_Hotel_3D_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTourHeaderDetailAPIController : ControllerBase
    {
        private readonly IOrderTourHeaderRepository _repository;
        private readonly AuthMiddleWare _authMiddleWare;

        public OrderTourHeaderDetailAPIController(IOrderTourHeaderRepository repository, AuthMiddleWare authMiddleWare)
        {
            _repository = repository;
            _authMiddleWare = authMiddleWare;
        }

        [HttpGet("/getOrderTourHeaderByUserId")]
        public async Task<IActionResult> getOrderTourHeaderByUserId()
        {
            var userId = _authMiddleWare.GetUserIdFromToken(HttpContext);
            var check = await _repository.getOrderTourHeaderByUserId(userId.Value);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }
    }
}
