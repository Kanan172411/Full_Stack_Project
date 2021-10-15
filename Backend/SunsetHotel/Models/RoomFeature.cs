using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class RoomFeature
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string Icon { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
        public List<RoomFeatureRelation> RoomFeatureRelations { get; set; }
    }
}
