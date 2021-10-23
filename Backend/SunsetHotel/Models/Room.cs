using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public List<IFormFile> Images { get; set; }
        [NotMapped]
        public List<int> FeatureId { get; set; }
        [NotMapped]
        public List<int> ImageIds { get; set; }
        [Range(1,5)]
        [Required]
        public int MaxChild { get; set; }
        [Range(1, 5)]
        [Required]
        public int MaxAdult { get; set; }
        public List<Reservation> reservations { get; set; }
        public List<RoomComment> Comments { get; set; }
    }
}
