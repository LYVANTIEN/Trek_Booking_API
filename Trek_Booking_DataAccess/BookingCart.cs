﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trek_Booking_DataAccess
{
    public class BookingCart
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingCartId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }


        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }



        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room? Room { get; set; }



        [DataType(DataType.Date)]
        public DateTime? CheckInDate { get; set; }


        [DataType(DataType.Date)]
        public DateTime? CheckOutDate { get; set; }

        public decimal TotalPrice { get; set; }
        public int RoomQuantity { get; set; }
        public string? VoucherCode { get; set; }

    }
}
