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
        [HttpGet("/getSuppliers")]
        public async Task<IActionResult> getSuppliers()
        {
            var c = await _repository.getSuppliers();
            if (c == null)
            {
                return NotFound("Not Found");
            }
            return Ok(c);
        }
        [HttpGet("/getSupplierbyId/{supplierId}")]
        public async Task<IActionResult> getHotelbyId(int supplierId)
        {
            var check = await _repository.getSupplierbyId(supplierId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }
        [HttpPost("/createSupplier")]
        public async Task<IActionResult> createSupplier([FromBody] Supplier supplier)
        {
            if (supplier == null)
            {
                return BadRequest();
            }
            else if (await _repository.checkExitsName(supplier.SupplierName))
            {
                return BadRequest("SupplierName already exits");
            }
            var create = await _repository.createSupplier(supplier);
            return StatusCode(201, "Create Successfully!");
        }
        [HttpPut("/updateSupplier")]
        public async Task<IActionResult> updateSupplier([FromBody] Supplier supplier)
        {
            var check = await _repository.getSupplierbyId(supplier.SupplierId);
            if (check == null)
            {
                return BadRequest("Not found Supplier");
            }
            var update = await _repository.updateSupplier(supplier);
            return Ok(update);
        }
        [HttpDelete("/deleteSupplier/{supplierId}")]
        public async Task<IActionResult> deleteSupplier(int supplierId)
        {
            var check = await _repository.getSupplierbyId(supplierId);
            if (check == null)
            {
                return NotFound("Not found Supplier");
            }
            await _repository.deleteSupplier(supplierId);
            return StatusCode(200, "Delele Successfully!");
        }
    }
}
