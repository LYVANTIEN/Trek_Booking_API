using Microsoft.AspNetCore.Mvc;
using Trek_Booking_DataAccess;
using Trek_Booking_Repository.Repositories.IRepositories;

namespace Trek_Booking_Hotel_3D_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierStaffAPIController : ControllerBase
    {
        private readonly ISupplierStaffRepository _repository;

        public SupplierStaffAPIController(ISupplierStaffRepository repository)
        {
            _repository = repository;
        }

        [HttpPut("ToggleSupplierStaff")]
        public async Task<IActionResult> ToggleStatus([FromBody] ToggleSupplierStaffRequest request)
        {
            return await _repository.ToggleStatus(request);
        }
        [HttpGet("/getSupplierStaffs")]
        public async Task<IActionResult> getSupplierStaffs()
        {
            var staffs = await _repository.getSupplierStaffs();
            if (staffs == null)
            {
                return NotFound("Not Found");
            }
            return Ok(staffs);
        }
        [HttpGet("/getSupplierStaffbyId/{staffId}")]
        public async Task<IActionResult> getSupplierStaffbyId(int staffId)
        {
            var check = await _repository.getSupplierStaffbyId(staffId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }
        [HttpGet("/getSupplierStaffBySupplierId/{supplierId}")]
        public async Task<IActionResult> getSupplierStaffBySupplierId(int supplierId)
        {
            var check = await _repository.getSupplierStaffBySupplierId(supplierId);
            if (check == null)
            {
                return NotFound("Not Found");
            }
            return Ok(check);
        }
        [HttpPost("/createSupplierStaff")]
        public async Task<IActionResult> createSupplier([FromBody] SupplierStaff supplierStaff)
        {
            if (supplierStaff == null)
            {
                return BadRequest();
            }
            else if (await _repository.checkExitsEmail(supplierStaff.StaffEmail))
            {
                return BadRequest("SupplierEmail already exits");
            }
            var create = await _repository.createSupplierStaff(supplierStaff);
            return StatusCode(201, "Create Successfully!");
        }
        [HttpPut("/updateSupplierStaff")]
        public async Task<IActionResult> updateSupplierStaff([FromBody] SupplierStaff supplierStaff)
        {
            var check = await _repository.getSupplierStaffbyId(supplierStaff.StaffId);
            if (check == null)
            {
                return BadRequest("Not found Supplier");
            }
            var update = await _repository.updateSupplierStaff(supplierStaff);
            return Ok(update);
        }
        [HttpDelete("/deleteSupplierStaff/{staffId}")]
        public async Task<IActionResult> deleteSupplierStaff(int staffId)
        {
            var check = await _repository.getSupplierStaffbyId(staffId);
            if (check == null)
            {
                return NotFound("Not found Supplier");
            }
            await _repository.deleteSupplierStaff(staffId);
            return StatusCode(200, "Delele Successfully!");
        }
    }
}
