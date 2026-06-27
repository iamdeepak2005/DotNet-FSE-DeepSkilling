using System;

namespace Algorithms.SortingOrders
{
    public class Order
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public Order(int id, double price) { Id = id; Price = price; }
    }

    class Program
    {
        // bubble sort loops elements comparing neighbors, time complexity O(N^2)
        public static void BubbleSort(Order[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j].Price > arr[j + 1].Price)
                    {
                        Order temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        // quick sort partitions list dynamically, average time complexity O(N log N)
        public static void QuickSort(Order[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIdx = Partition(arr, low, high);
                QuickSort(arr, low, pivotIdx - 1);
                QuickSort(arr, pivotIdx + 1, high);
            }
        }

        private static int Partition(Order[] arr, int low, int high)
        {
            double pivot = arr[high].Price;
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (arr[j].Price < pivot)
                {
                    i++;
                    Order temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            Order temp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp2;
            return i + 1;
        }

        static void Main()
        {
            Order[] list = {
                new Order(1, 250.0),
                new Order(2, 50.0),
                new Order(3, 175.0)
            };

            BubbleSort(list);
            Console.WriteLine("Sorted order prices:");
            foreach (var o in list)
            {
                Console.WriteLine($"Order {o.Id} -> Price: ${o.Price}");
            }
        }
    }
}