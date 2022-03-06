using Microsoft.EntityFrameworkCore;
using OleevAppK310.Models;

namespace OleevAppK310.Models
{
    public class OlDbContext:DbContext
    {
        public OlDbContext(DbContextOptions<OlDbContext> opt):base(opt)
        {
        }
        public DbSet<Section1> Section1s { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Reserv> reservs { get; set; }  
        public DbSet<ReservCategory> ReservCategory { get; set; }   
        public DbSet<SaleProduct> saleProducts { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; } 
        public DbSet<Service> services  { get; set; }
        public DbSet<Fact> Fatcs { get; set; }
    }
}
