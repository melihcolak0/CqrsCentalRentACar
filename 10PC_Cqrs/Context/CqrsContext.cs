using _10PC_Cqrs.Entities;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.Context
{
    public class CqrsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SG606F1\\SQLEXPRESS; Initial Catalog = 10PC_CqrsDb;" +
                " Integrated Security = true; Trust Server Certificate = true");
        }
        
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
