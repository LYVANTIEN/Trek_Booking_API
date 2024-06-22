using Trek_Booking_DataAccess;

namespace Trek_Booking_Hotel_3D_API.Service
{
    public interface IJwtUtils
    {
        public string GenerateTokenClient(User user);
        public string GenerateTokenSupplier(Supplier supplier);
        public int? ValidateUserToken(string token);
        //authen
        public int? ValidateSupplierToken(string token);
    }
}
