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
    [Table("Role")]
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "Role not null")]
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        [JsonIgnore]

        public ICollection<User>? users { get; set; }
        [JsonIgnore]

        public ICollection<Supplier>? suppliers { get; set; }
        [JsonIgnore]

        public ICollection<SupplierStaff>? supplierStaffs { get; set; }
    }
}
