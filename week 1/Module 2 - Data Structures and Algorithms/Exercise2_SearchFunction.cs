using System;

namespace Algorithms.SearchFunction
{
    public class Product : IComparable<Product>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Product(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public int CompareTo(Product other) => string.Compare(Id, other.Id, StringComparison.OrdinalIgnoreCase);
    }

    class Program
    {
        // linear search iterates elements one by one, giving time complexity of O(N)
        public static Product LinearSearch(Product[] list, string targetId)
        {
            foreach (var item in list)
            {
                if (item.Id == targetId) return item;
            }
            return null;
        }

        // binary search cuts search space in half, giving O(log N) complexity but needs sorted list
        public static Product BinarySearch(Product[] sortedList, string targetId)
        {
            int low = 0;
            int high = sortedList.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int cmp = string.Compare(sortedList[mid].Id, targetId, StringComparison.OrdinalIgnoreCase);

                if (cmp == 0) return sortedList[mid];
                else if (cmp < 0) low = mid + 1;
                else high = mid - 1;
            }
            return null;
        }

        static void Main()
        {
            Product[] list = {
                new Product("P3", "Keyboard"),
                new Product("P1", "Monitor"),
                new Product("P2", "Mouse")
            };

            Console.WriteLine("Linear search checking:");
            Product res = LinearSearch(list, "P1");
            Console.WriteLine(res != null ? "Found: " + res.Name : "Not found");

            // sort array to apply binary search
            Array.Sort(list);
            Console.WriteLine("\nBinary search checking:");
            Product res2 = BinarySearch(list, "P1");
            Console.WriteLine(res2 != null ? "Found: " + res2.Name : "Not found");
        }
    }
}