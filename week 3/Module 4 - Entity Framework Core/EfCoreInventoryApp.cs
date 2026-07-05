using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Training.Week3.EFCore
{
    // Category Entity
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // One-to-Many Relationship
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

    // Product Entity
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    // Database Context Class
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // using local in-memory DB to run easily without SQL server installed
            optionsBuilder.UseInMemoryDatabase("TrainingStoreDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API config
            modelBuilder.Entity<Product>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(150);

            // Seeding default categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Office" }
            );
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- entity framework core 8 exercises ---");

            using (var db = new StoreContext())
            {
                // 1. Seed data execution
                db.Database.EnsureCreated();

                // 2. Insert Category & Products (CRUD: Create)
                var electronics = new Category { Name = "Computing Tools" };
                var prod1 = new Product { Title = "Dell UltraSharp Monitor", Cost = 350.00m, Category = electronics };
                
                db.Categories.Add(electronics);
                db.Products.Add(prod1);
                db.SaveChanges(); // Persist changes

                // 3. Read items using LINQ & Eager Loading (Include)
                Console.WriteLine("\nRetrieving products (Eager Loading):");
                var productsList = db.Products
                    .Include(p => p.Category)
                    .ToList();

                foreach (var p in productsList)
                {
                    Console.WriteLine($"Product: {p.Title} | Category: {p.Category.Name} | Cost: ${p.Cost}");
                }

                // 4. Update Product (CRUD: Update)
                var target = db.Products.FirstOrDefault(p => p.Title.Contains("Monitor"));
                if (target != null)
                {
                    target.Cost = 320.00m; // discount price
                    db.SaveChanges();
                    Console.WriteLine($"\nUpdated cost of {target.Title} to: ${target.Cost}");
                }

                // 5. Delete Product (CRUD: Delete)
                db.Products.Remove(prod1);
                db.SaveChanges();
                Console.WriteLine("\nProduct deleted successfully from inventory database.");
            }
        }
    }
}