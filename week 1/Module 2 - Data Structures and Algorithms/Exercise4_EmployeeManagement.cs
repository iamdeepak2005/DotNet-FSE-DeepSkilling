using System;

namespace Algorithms.EmployeeManagement
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee(int id, string name) { Id = id; Name = name; }
    }

    public class Registry
    {
        private readonly Employee[] _arr;
        private int _size = 0;

        public Registry(int limit)
        {
            _arr = new Employee[limit];
        }

        public void Insert(Employee emp)
        {
            if (_size >= _arr.Length) return;
            _arr[_size] = emp;
            _size++;
        }

        public Employee Find(int id)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_arr[i].Id == id) return _arr[i];
            }
            return null;
        }

        public void Delete(int id)
        {
            int idx = -1;
            for (int i = 0; i < _size; i++)
            {
                if (_arr[i].Id == id) { idx = i; break; }
            }

            if (idx == -1) return;

            // shift items left
            for (int i = idx; i < _size - 1; i++)
            {
                _arr[i] = _arr[i + 1];
            }
            _arr[_size - 1] = null;
            _size--;
        }

        public void Print()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine($" - ID: {_arr[i].Id}, Name: {_arr[i].Name}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Registry reg = new Registry(10);
            reg.Insert(new Employee(101, "Amit"));
            reg.Insert(new Employee(102, "Deepa"));

            reg.Print();
            reg.Delete(101);
            Console.WriteLine("\nAfter delete:");
            reg.Print();
        }
    }
}