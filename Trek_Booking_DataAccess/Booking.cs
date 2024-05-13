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
    public class Booking
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }


        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        [JsonIgnore]
        public Hotel? Hotel { get; set; }


        [ForeignKey("Room")]
        public int RoomId { get; set; }
        [JsonIgnore]
        public Room? Room { get; set; }


        [DataType(DataType.Date)]
        public DateTime? CheckInDate { get; set; }


        [DataType(DataType.Date)]
        public DateTime? CheckOutDate { get; set; }

        public decimal TotalPrice { get; set; }
        public int RoomQuantity { get; set; }
        public string? VoucherCode { get; set; }
        public bool Status { get; set; }
        [JsonIgnore]
        public ICollection<VoucherUsageHistory>? voucherUsageHistory { get; set; }
        [JsonIgnore]
        public ICollection<Comment>? comments { get; set; }
        [JsonIgnore]
        public ICollection<Rate>? rates { get; set; }
    }
}
