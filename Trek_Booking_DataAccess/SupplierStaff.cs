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
    [Table("SupplierStaff")]
    public class SupplierStaff
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }
        public string? StaffName { get; set; }

        
        [DataType(DataType.PhoneNumber)]
        public string? StaffPhoneNumber { get; set; }

      
        [StringLength(100, ErrorMessage = "The Email must be greater than 0 and less than or equal 100")]
        public string? StaffEmail { get; set; }
        public string? Avatar { get; set; }
     
        public string? StaffPassword { get; set; }

        [StringLength(300, ErrorMessage = "The Address must be less than or equal 300")]
        public string? StaffAddress { get; set; }
        public bool Status { get; set; }
        public bool IsVerify { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
