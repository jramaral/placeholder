using Desafio.Model;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Data
{
   
   
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.Address)
                .WithOne(b => b.User)
                .HasForeignKey<Address>(b => b.UserId);
            
            modelBuilder.Entity<User>()
                .HasOne(a =>a.Company )
                .WithOne(b => b.User)
                .HasForeignKey<Company>(b => b.UserId);
        }

    }
}