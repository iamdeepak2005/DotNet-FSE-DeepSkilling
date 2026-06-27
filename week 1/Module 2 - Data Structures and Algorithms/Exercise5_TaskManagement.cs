using System;

namespace Algorithms.TaskManagement
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Task(int id, string name) { Id = id; Name = name; }
    }

    public class Node
    {
        public Task Data { get; set; }
        public Node Next { get; set; }
        public Node(Task data) { Data = data; }
    }

    public class TaskList
    {
        private Node _head;

        public void Append(Task t)
        {
            Node n = new Node(t);
            if (_head == null) { _head = n; return; }

            Node curr = _head;
            while (curr.Next != null) curr = curr.Next;
            curr.Next = n;
        }

        public void Remove(int id)
        {
            if (_head == null) return;
            if (_head.Data.Id == id) { _head = _head.Next; return; }

            Node curr = _head;
            while (curr.Next != null)
            {
                if (curr.Next.Data.Id == id)
                {
                    curr.Next = curr.Next.Next;
                    return;
                }
                curr = curr.Next;
            }
        }

        public void ListAll()
        {
            Node curr = _head;
            while (curr != null)
            {
                Console.WriteLine($"Task ID: {curr.Data.Id}, Name: {curr.Data.Name}");
                curr = curr.Next;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            TaskList list = new TaskList();
            list.Append(new Task(1, "Create DB"));
            list.Append(new Task(2, "Test Controllers"));

            list.ListAll();
            list.Remove(1);
            Console.WriteLine("\nAfter remove:");
            list.ListAll();
        }
    }
}