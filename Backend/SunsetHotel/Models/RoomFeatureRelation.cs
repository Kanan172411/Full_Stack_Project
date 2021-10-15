using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class RoomFeatureRelation
    {
        public int Id { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public int RoomFeatureId { get; set; }
        public Room Room { get; set; }
        public RoomFeature RoomFeature { get; set; }
    }
}
