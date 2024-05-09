﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Trek_Booking_DataAccess
{
    public class Room
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "RoomName is not null")]
        public string? RoomName { get; set; }

        [Required(ErrorMessage = "RoomDescription is not null")]
        public string? RoomDescription { get; set; }

        [Required(ErrorMessage = "RoomNote is not null")]
        public string? RoomNote { get; set; }

        public bool RoomStatus { get; set; }
        public int RoomAvailable { get; set; }

        [Required(ErrorMessage = "RoomPrice is not null")]
        public decimal RoomPrice { get; set; }
        [Required(ErrorMessage = "RoomCapacity is not null")]
        public int RoomCapacity { get; set; }

        public float DiscountPercent { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        [JsonIgnore]
        public Hotel? Hotel { get; set; }
        [JsonIgnore]
        public ICollection<Room3DImage>? room3DImages { get; set; }
        [JsonIgnore]
        public ICollection<RoomImage>? roomImages { get; set; }
        [JsonIgnore]
        public ICollection<RoomService>? roomServices { get; set; }
        [JsonIgnore]
        public ICollection<BookingCart>? bookingCarts { get; set; }
        [JsonIgnore]
        public ICollection<Booking>? bookings { get; set; }
    }
}
