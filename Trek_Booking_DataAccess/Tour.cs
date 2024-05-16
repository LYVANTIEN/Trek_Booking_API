﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trek_Booking_DataAccess
{
    [Table("Tour")]
    public class Tour
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TourId { get; set; }

        [Required(ErrorMessage = "TourName is not null")]
        public string? TourName { get; set; }

        [Required(ErrorMessage = "TourDescription is not null")]
        public string? TourDescription { get; set; }

        [Required(ErrorMessage = "TourPrice is not null")]
        public decimal? TourPrice { get; set; }

        [Required(ErrorMessage = "TourAddress is not null")]
        public string? TourAddress { get; set; }

        [Required(ErrorMessage = "TourTime is not null")]
        public string? TourTime { get; set; }

        [Required(ErrorMessage = "TourTransportation is not null")]
        public string? TourTransportation { get; set; }

        [Required(ErrorMessage = "TourCapacity is not null")]
        public int TourCapacity { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public ICollection<CartTour>? cartTours { get; set; }
        public ICollection<TourImage>? tourImages { get; set; }
        public ICollection<TourOrder>? tourOrders { get; set; }
    }
}
