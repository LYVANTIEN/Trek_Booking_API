using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trek_Booking_DataAccess;

namespace Trek_Booking_Repository.Repositories.IRepositories
{
    public interface IServiceRepository
    {
        public Task<Service> createService(Service service);
        public Task<Service> updateService(Service service);
        public Task<int> deleteService(int serviceId);
        public Task<Service> getServicebyId(int serviceId);
        public Task<IEnumerable<Service>> getServices();

        public Task<bool> checkExitsName(string name);
    }
}
