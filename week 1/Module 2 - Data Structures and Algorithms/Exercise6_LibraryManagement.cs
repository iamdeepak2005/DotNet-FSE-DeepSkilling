using System;

namespace Algorithms.LibraryManagement
{
    public class Book : IComparable<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Book(string title, string author) { Title = title; Author = author; }
        public int CompareTo(Book other) => string.Compare(Title, other.Title, StringComparison.OrdinalIgnoreCase);
    }

    class Program
    {
        // linear search matches titles sequentially O(N)
        public static Book FindLinear(Book[] list, string target)
        {
            foreach (var b in list)
            {
                if (string.Equals(b.Title, target, StringComparison.OrdinalIgnoreCase)) return b;
            }
            return null;
        }

        // binary search matches sorted catalog O(log N)
        public static Book FindBinary(Book[] sortedList, string target)
        {
            int low = 0;
            int high = sortedList.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int cmp = string.Compare(sortedList[mid].Title, target, StringComparison.OrdinalIgnoreCase);

                if (cmp == 0) return sortedList[mid];
                else if (cmp < 0) low = mid + 1;
                else high = mid - 1;
            }
            return null;
        }

        static void Main()
        {
            Book[] catalog = {
                new Book("Clean Code", "Uncle Bob"),
                new Book("Design Patterns", "GoF"),
                new Book("C# in Depth", "Jon Skeet")
            };

            Book res = FindLinear(catalog, "Clean Code");
            Console.WriteLine(res != null ? "Found: " + res.Title : "Not found");

            Array.Sort(catalog);
            Book res2 = FindBinary(catalog, "Clean Code");
            Console.WriteLine(res2 != null ? "Found: " + res2.Title : "Not found");
        }
    }
}