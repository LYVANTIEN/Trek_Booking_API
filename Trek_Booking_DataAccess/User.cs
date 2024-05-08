using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trek_Booking_DataAccess
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "UserName is not null")]
        [StringLength(20, ErrorMessage = "The UserName must be greater than 0 and less than or equal 20")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is not null")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "The Email must be greater than 0 and less than or equal 100")]
        public string? Email { get; set; }

        [StringLength(12, ErrorMessage = "The Phone must be equal 12 number")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [StringLength(300, ErrorMessage = "The Address must be less than or equal 300")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Password is not null")]
        [StringLength(50, ErrorMessage = "The Password must be greater than 0 and less than or equal 50")]
        public string? Password { get; set; }
        public bool Status { get; set; }
        public bool IsVerify { get; set; }
        public ICollection<PaymentInformation>? paymentInformations { get; set; }
        public ICollection<CartTour>? cartTours { get; set; }
        public ICollection<TourOrder>? tourOrders { get; set; }
        public ICollection<Comment>? comments { get; set; }
        public ICollection<Rate>? rates { get; set; }
        public ICollection<BookingCart>? bookingCarts { get; set; }
        public ICollection<Booking>? bookings { get; set; }
        public ICollection<VoucherUsageHistory>? voucherUsageHistories { get; set; }
    }
}
