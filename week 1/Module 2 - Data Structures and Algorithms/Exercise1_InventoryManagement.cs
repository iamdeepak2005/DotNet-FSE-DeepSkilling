using System;
using System.Collections.Generic;

namespace Algorithms.InventoryManagement
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        public Product(string id, string name, int stock, double price)
        {
            Id = id;
            Name = name;
            Stock = stock;
            Price = price;
        }
    }

    public class Inventory
    {
        // dictionary matches key search mapping providing constant lookup time O(1)
        private readonly Dictionary<string, Product> _db = new Dictionary<string, Product>();

        public void Add(Product p)
        {
            if (_db.ContainsKey(p.Id)) return;
            _db.Add(p.Id, p);
            Console.WriteLine($"Added: {p.Name}");
        }

        public void Update(string id, int newStock, double newPrice)
        {
            if (!_db.TryGetValue(id, out Product p)) return;
            p.Stock = newStock;
            p.Price = newPrice;
            Console.WriteLine($"Updated: {p.Name}");
        }

        public void Delete(string id)
        {
            if (!_db.ContainsKey(id)) return;
            _db.Remove(id);
            Console.WriteLine($"Deleted ID: {id}");
        }

        public void PrintAll()
        {
            Console.WriteLine("\n--- Products ---");
            foreach (var item in _db.Values)
            {
                Console.WriteLine($" - {item.Name} | Stock: {item.Stock} | Price: ${item.Price}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Inventory inv = new Inventory();
            inv.Add(new Product("P1", "Laptop", 10, 1200));
            inv.Add(new Product("P2", "Phone", 25, 750));

            inv.PrintAll();
            inv.Update("P2", 20, 720);
            inv.Delete("P1");
            inv.PrintAll();
        }
    }
}