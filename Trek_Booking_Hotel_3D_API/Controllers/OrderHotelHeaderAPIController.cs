﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trek_Booking_DataAccess;
using Trek_Booking_Hotel_3D_API.Helper;
using Trek_Booking_Repository.Repositories.IRepositories;

namespace Trek_Booking_Hotel_3D_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHotelHeaderAPIController : ControllerBase
    {
        private readonly IOrderHotelHeaderRepository _repository;
        private readonly AuthMiddleWare _authMiddleWare;

        public OrderHotelHeaderAPIController(IOrderHotelHeaderRepository repository, AuthMiddleWare authMiddleWare)
        {
            _repository = repository;
            _authMiddleWare = authMiddleWare;
        }

        [HttpGet("/getOrderHotelHeaderByUserId")]
        public async Task<IActionResult> getOrderHotelHeaderByUserId()
        {
            var userId = _authMiddleWare.GetUserIdFromToken(HttpContext);
            var check = await _repository.getOrderHotelHeaderByUserId(userId.Value);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }

        [HttpGet("/getOrderHotelHeaderBySupplierId")]
        public async Task<IActionResult> getOrderHotelHeaderBySupplierId()
        {
            var supplierId = _authMiddleWare.GetSupplierIdFromToken(HttpContext);
            var check = await _repository.getOrderHotelHeaderBySupplierId(supplierId.Value);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }

        [HttpPut("/updateOrderHotelHeader")]
        public async Task<IActionResult> updateOrderHotelHeader(OrderHotelHeader orderHotelHeader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var check = await _repository.getOrderHotelHeaderByUserId(orderHotelHeader.Id);
            if (check == null)
            {
                return BadRequest("Not found Order Hotel Header");
            }
            var update = await _repository.updateOrderHotelHeader(orderHotelHeader);
            return Ok(update);
        }
    }
}
