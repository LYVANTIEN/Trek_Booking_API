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
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDBContext _context;

        public SupplierRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> checkExitsName(string name)
        {
            var check = await _context.suppliers.AnyAsync(n => n.SupplierName == name);
            return check;
        }

        public async Task<Supplier> createSupplier(Supplier supplier)
        {

            supplier.IsVerify = true;
            _context.suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<int> deleteSupplier(int supplierId)
        {
            var deleteSupplier = await _context.suppliers.FirstOrDefaultAsync(t => t.SupplierId == supplierId);
            if (deleteSupplier != null)
            {
                _context.suppliers.Remove(deleteSupplier);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Supplier> getSupplierById(int supplierId)
        {
            var getSupplier = await _context.suppliers.FirstOrDefaultAsync(t => t.SupplierId == supplierId);
            return getSupplier;
        }

        public async Task<IEnumerable<Supplier>> getSuppliers()
        {
            var suppliers = await _context.suppliers.ToListAsync();
            return suppliers;
        }

        public async Task<Supplier> updateSupplier(Supplier supplier)
        {
            var findSupplier = await _context.suppliers.FirstOrDefaultAsync(t => t.SupplierId == supplier.SupplierId);
            if (findSupplier != null)
            {
                findSupplier.SupplierName = supplier.SupplierName;
                findSupplier.Email = supplier.Email;
                findSupplier.Phone = supplier.Phone;
                findSupplier.Address = supplier.Address;
                //findSupplier.Password = Supplier.SupplierAvatar;
                //findSupplier.Status = supplier.Status;
                //findSupplier.IsVerify = supplier.IsVerify;
                //findSupplier.Role = supplier.Role;
                _context.suppliers.Update(findSupplier);
                await _context.SaveChangesAsync();
                return findSupplier;
            }
            return null;
        }
    }
}
