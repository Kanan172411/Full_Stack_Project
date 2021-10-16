using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 800)]
        public string Desc { get; set; }
        [Required]
        [Range(5,1000)]
        public int Price { get; set; }
        public int RoomCategoryId { get; set; }
        public RoomCategory Categories { get; set; }
        public List<RoomImage> RoomImages { get; set; }
        public List<RoomFeatureRelation> RoomFeatureRelations { get; set; }
    }
}
