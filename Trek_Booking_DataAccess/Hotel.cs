using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Trek_Booking_DataAccess
{
    [Table("Hotel")]
    public class Hotel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelId { get; set; }

        [Required(ErrorMessage = "HotelName is not null")]
        [StringLength(100, ErrorMessage = "The UserName must be greater than 0 and less than or equal 100")]
        public string? HotelName { get; set; }

        [Required(ErrorMessage = "HotelPhone is not null")]
        [StringLength(50, ErrorMessage = "The UserName must be greater than 0 and less than or equal 50")]
        public string? HotelPhone { get; set; }

        [Required(ErrorMessage = "HotelEmail is not null")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "The HotelEmail must be greater than 0 and less than or equal 100")]
        public string? HotelEmail { get; set; }

        [Required(ErrorMessage = "HotelAvatar is not null")]
        public string? HotelAvatar { get; set; }

        [Required(ErrorMessage = "Description is not null")]
        public string? HotelFulDescription { get; set; }

        [Required(ErrorMessage = "HotelDistrict is not null")]
        public string? HotelDistrict { get; set; }

        [Required(ErrorMessage = "HotelCity is not null")]
        [StringLength(200, ErrorMessage = "The HotelCity must be greater than 0 and less than or equal 200 ")]
        public string? HotelCity { get; set; }

        [Required(ErrorMessage = "HotelInformation is not null")]
        public string? HotelInformation { get; set; }

        public bool IsVerify { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public ICollection<Comment>? comments { get; set; }
        public ICollection<Rate>? rates { get; set; }

        public ICollection<BookingCart>? bookingCarts { get; set; }

        public ICollection<Booking>? bookings { get; set; }

        public ICollection<Room>? rooms { get; set; }

        public ICollection<Voucher>? vouchers { get; set; }
    }
}
