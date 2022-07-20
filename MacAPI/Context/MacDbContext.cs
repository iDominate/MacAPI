using MacAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MacAPI.Context
{
    public class MacDbContext : DbContext
    {

        public MacDbContext(DbContextOptions<MacDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<MacAddressInfo>()
                .Property(e => e.Id)
                .IsRequired();
            modelBuilder.Entity<MacAddressInfo>()
                .Property(m => m.MacAddress)
                .HasMaxLength(12)
                .IsFixedLength();
            modelBuilder.Entity<MacAddressInfo>()
                .Property(m => m.Date)
                .IsRequired();
        }

        public DbSet<MacAddressInfo> MacAddresses { get; set; }
    }
    
}
