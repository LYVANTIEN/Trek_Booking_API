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
    public class CartTour
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartTourId { get; set; }
        [ForeignKey("Tour")]
        public int TourId { get; set; }
        [JsonIgnore]
        public Tour? Tour { get; set; }
        public int TourQuantity { get; set; }
        public decimal TourPrice { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
