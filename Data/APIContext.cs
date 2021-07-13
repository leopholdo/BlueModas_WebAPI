using Microsoft.EntityFrameworkCore;
using BlueModas_WebAPI.Models;

namespace BlueModas_WebAPI.Data
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        public DbSet<TabOrder> TabOrder { get; set; }
        public DbSet<TabClient> TabClient { get; set; }
        public DbSet<TabProduct> TabProduct { get; set; }
        public DbSet<TabProductBasket> TabProductBasket { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TabClient>()
                .HasIndex(u => u.tclEmail)
                .IsUnique();
        }
    }
}