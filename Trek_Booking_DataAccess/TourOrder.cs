
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
    [Table("TourOrder")]
    public class TourOrder
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TourOrderId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        [JsonIgnore]
        public Supplier? Supplier { get; set; }

        [ForeignKey("Tour")]
        public int TourId { get; set; }
        [JsonIgnore]
        public Tour? Tour { get; set; }

        [DataType(DataType.Date)]   
        public DateTime? TourOrderDate { get; set; }
        [Required(ErrorMessage ="TourOrderQuantity is not null")]
        public int TourOrderQuantity { get; set; }
        [Required(ErrorMessage = "TourOrderQuantity is not null")]
        public decimal TourTotalPrice { get; set; } 

        public bool IsConfirmed { get; set; }   
        public bool Status { get; set; }
    }
}
