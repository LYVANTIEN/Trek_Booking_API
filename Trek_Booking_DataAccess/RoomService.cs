using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trek_Booking_DataAccess
{
    public class RoomService
    {
        [Key]
        public int RoomId { get; set; }
        public Room? Room { get; set; }

        [Key]
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}
