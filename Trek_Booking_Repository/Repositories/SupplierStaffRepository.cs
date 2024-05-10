using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trek_Booking_DataAccess.Data;
using Trek_Booking_DataAccess;
using Trek_Booking_Repository.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Trek_Booking_Repository.Repositories
{
    public class SupplierStaffRepository : ISupplierStaffRepository
    {
        private readonly ApplicationDBContext _context;

        public SupplierStaffRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> checkExitsEmail(string email)
        {
            var check = await _context.supplierStaff.AnyAsync(n => n.StaffEmail == email);
            return check;
        }

        public async Task<SupplierStaff> createSupplierStaff(SupplierStaff supplierStaff)
        {

            _context.supplierStaff.Add(supplierStaff);
            await _context.SaveChangesAsync();
            return supplierStaff;
        }

        public async Task<int> deleteSupplierStaff(int staffId)
        {
            var deleteSupplierStaff = await _context.supplierStaff.FirstOrDefaultAsync(t => t.StaffId == staffId);
            if (deleteSupplierStaff != null)
            {
                _context.supplierStaff.Remove(deleteSupplierStaff);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<SupplierStaff> getSupplierStaffbyId(int staffId)
        {
            var getSupplierStaff = await _context.supplierStaff.FirstOrDefaultAsync(t => t.StaffId == staffId);
            return getSupplierStaff;
        }
        public async Task<IEnumerable<SupplierStaff>> getSupplierStaffBySupplierId(int supplierId)
        {
            var getSupplierStaffBySupplierId = await _context.supplierStaff.Where(t => t.SupplierId == supplierId).ToListAsync();
            return getSupplierStaffBySupplierId;
        }
        public async Task<IEnumerable<SupplierStaff>> getSupplierStaffs()
        {
            var supplierStaff = await _context.supplierStaff.ToListAsync();
            return supplierStaff;
        }

        public async Task<SupplierStaff> updateSupplierStaff(SupplierStaff supplierStaff)
        {
            var findSupplierStaff = await _context.supplierStaff.FirstOrDefaultAsync(t => t.StaffId == supplierStaff.StaffId);
            if (findSupplierStaff != null)
            {
                findSupplierStaff.StaffName = supplierStaff.StaffName;
                findSupplierStaff.StaffPhoneNumber = supplierStaff.StaffPhoneNumber;
                findSupplierStaff.StaffEmail = supplierStaff.StaffEmail;
                findSupplierStaff.StaffPassword = supplierStaff.StaffPassword;
                findSupplierStaff.StaffAddress = supplierStaff.StaffAddress;

               
                _context.supplierStaff.Update(findSupplierStaff);
                await _context.SaveChangesAsync();
                return findSupplierStaff;
            }
            return null;
        }
    }
}
