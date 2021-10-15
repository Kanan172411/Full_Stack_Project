using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SunsetHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        DbSet<Testimonial> Testimonials { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<Gallery> Galleries { get; set; }
        DbSet<RoomCategory> RoomCategories { get; set; }
        DbSet<RoomFeature> RoomFeatures { get; set; }
        DbSet<RoomImage> RoomImages { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<RoomFeatureRelation> RoomFeatureRelations { get; set; }
        DbSet<BlogCategory> BlogCategories { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<Blog> Blogs { get; set; }
        DbSet<BlogTag> BlogTags { get; set; }
    }
}
