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
        public Task<Supplier> createSupplier(Supplier supplier);
        public Task<Supplier> updateSupplier(Supplier supplier);
        public Task<int> deleteSupplier(int supplierId);
        public Task<Supplier> getSupplierById(int supplierId);
        public Task<IEnumerable<Supplier>> getSuppliers();

        public Task<bool> checkExitsName(string name);
    }
}
