using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trek_Booking_DataAccess;

namespace Trek_Booking_Repository.Repositories.IRepositories
{
    public interface ISupplierRepository
    {
        public Task<Supplier> CreateSupplier(Supplier supplier);
        public Task<Supplier> UpdateSupplier(Supplier supplier);
        public Task<int> DeleteSupplier(int supplierId);
        public Task<Supplier> GetSupplierbyId(int supplierId);
        public Task<IEnumerable<Supplier>> GetSuppliers();

        public Task<bool> CheckExitsName(string name);
    }
}
