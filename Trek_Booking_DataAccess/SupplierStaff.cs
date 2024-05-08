﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trek_Booking_DataAccess
{
    public class SupplierStaff
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }

        [Required(ErrorMessage = "SupplierName is not null")]
        [StringLength(200, ErrorMessage = "The SupplierName must be greater than 0 and less than or equal 100")]
        public string? StaffName { get; set; }

        [StringLength(12, ErrorMessage = "The Phone must be equal 12 number")]
        [DataType(DataType.PhoneNumber)]
        public string? StaffPhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is not null")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "The Email must be greater than 0 and less than or equal 100")]
        public string? StaffEmail { get; set; }

        [Required(ErrorMessage = "Password is not null")]
        [StringLength(50, ErrorMessage = "The Password must be greater than 0 and less than or equal 50")]
        public string? StaffPassword { get; set; }

        [StringLength(300, ErrorMessage = "The Address must be less than or equal 300")]
        public string? StaffAddress { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        [Required(ErrorMessage = "Role is not null")]
        public string? Role { get; set; }
    }
}
