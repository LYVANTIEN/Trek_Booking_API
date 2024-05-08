using Microsoft.AspNetCore.Mvc;
using Trek_Booking_DataAccess;
using Trek_Booking_Repository.Repositories.IRepositories;

namespace Trek_Booking_Hotel_3D_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierAPIController : ControllerBase
    {
        private readonly ISupplierRepository _repository;

        public SupplierAPIController(ISupplierRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("/GetSuppliers")]
        public async Task<IActionResult> GetSuppliers()
        {
            var c = await _repository.GetSuppliers();
            if (c == null)
            {
                return NotFound("Not Found");
            }
            return Ok(c);
        }
        [HttpGet("/GetSupplierbyId/{supplierId}")]
        public async Task<IActionResult> GetHotelbyId(int supplierId)
        {
            var check = await _repository.GetSupplierbyId(supplierId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }
        [HttpPost("/CreateSupplier")]
        public async Task<IActionResult> CreateSupplier([FromBody] Supplier supplier)
        {
            if (supplier == null)
            {
                return BadRequest();
            }
            else if (await _repository.CheckExitsName(supplier.SupplierName))
            {
                return BadRequest("SupplierName already exits");
            }
            var create = await _repository.CreateSupplier(supplier);
            return StatusCode(201, "Create Successfully!");
        }
        [HttpPut("/UpdateSupplier")]
        public async Task<IActionResult> UpdateSupplier([FromBody] Supplier supplier)
        {
            var check = await _repository.GetSupplierbyId(supplier.SupplierId);
            if (check == null)
            {
                return BadRequest("Not found Supplier");
            }
            var update = await _repository.UpdateSupplier(supplier);
            return Ok(update);
        }
        [HttpDelete("/DeleteSupplier/{supplierId}")]
        public async Task<IActionResult> DeleteSupplier(int supplierId)
        {
            var check = await _repository.GetSupplierbyId(supplierId);
            if (check == null)
            {
                return NotFound("Not found Supplier");
            }
            await _repository.DeleteSupplier(supplierId);
            return StatusCode(200, "Delele Successfully!");
        }
    }
}
