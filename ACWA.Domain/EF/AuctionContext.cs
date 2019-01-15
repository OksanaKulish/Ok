using ACWA.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACWA.Domain.EF
{
    public class AuctionContext : DbContext
{
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    


    public AuctionContext(DbContextOptions<AuctionContext> dbContextOptions)
        : base(dbContextOptions)
    {
            Database.EnsureCreated();
    }
    
    public AuctionContext()
    {
        Database.EnsureCreated();
    }


    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=Auction;Trusted_Connection=True");
    }*/
    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        using (AuctionContext db = new AuctionContext())
        {
            Product p1 = new Product { Name = "lemon", Price = 23 };
            Product p2 = new Product { Name = "car", Price = 45 };
            db.Products.Add(p1);
            db.Products.Add(p2);
            db.SaveChanges();
            Category c1 = new Category { Name = "Food" };
            Category c2 = new Category { Name = "Transport" };
            db.Categories.AddRange(new List<Category> { c1, c2 });
            db.SaveChanges();
        }
    }*/

}

}
