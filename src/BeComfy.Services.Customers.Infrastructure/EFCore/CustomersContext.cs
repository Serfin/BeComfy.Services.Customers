using BeComfy.Services.Customers.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeComfy.Services.Customers.Infrastructure.EFCore
{
    public class CustomersContext : DbContext
    {
        public DbSet<Customer> Tickets { get; set; }

        public CustomersContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(x => x.Balance)
                .HasColumnType("money");
        }
    }
}