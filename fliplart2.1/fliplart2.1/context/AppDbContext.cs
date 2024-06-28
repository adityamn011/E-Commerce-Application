using fliplart2._1.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fliplart2._1.context
{
    public class AppDbContext : DbContext
    {
        
        
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }
            public DbSet<User> Users { get; set; }
            public DbSet<Product> Products { get; set; }
            

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>().ToTable("users");
                modelBuilder.Entity<Product>().ToTable("Products");   

        }
        

    }
}
