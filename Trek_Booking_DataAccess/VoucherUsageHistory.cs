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
    [Table("VoucherUsageHistory")]
    public class VoucherUsageHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserVoucherId { get; set; }


        [ForeignKey("Voucher")]
        public int VoucherId { get; set; }
        [JsonIgnore]
        public Voucher? Voucher { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }


        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        [JsonIgnore]
        public Booking? Booking { get; set; }
    }
}
