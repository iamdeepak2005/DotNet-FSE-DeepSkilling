using System;
using System.Collections.Generic;
using System.Data;

namespace Training.Upskilling
{
    // primary constructor demo (C# 12)
    public class Person(int id, string name, string location)
    {
        public int Id { get; } = id;
        public string Name { get; } = name;
        public string Location { get; } = location;

        public void Print()
        {
            Console.WriteLine($"Name: {Name}, Lives in: {Location} (ID: {Id})");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- upsilling exercises ---");

            // value vs reference types demo
            int valA = 100;
            int valB = valA;
            valB = 200;
            Console.WriteLine($"value type values: valA={valA}, valB={valB}");

            int[] arrA = { 10, 20 };
            int[] arrB = arrA;
            arrB[0] = 999;
            Console.WriteLine($"reference type values: arrA[0]={arrA[0]}, arrB[0]={arrB[0]}");

            // type inference and target-typed new()
            var text = "hello dotnet";
            List<Person> list = new(); // target typed new
            list.Add(new Person(1, "Amit", "Mumbai"));
            list.Add(new Person(2, "Deepa", "Bangalore"));

            foreach (var p in list)
            {
                p.Print();
            }

            // parameter keywords
            int score = 50;
            DoubleScore(ref score);
            Console.WriteLine("doubled via ref parameter: " + score);

            int generatedId;
            CreateId(out generatedId);
            Console.WriteLine("generated out id: " + generatedId);

            // simulate ADO.NET classes
            Console.WriteLine("\nsimulating ADO.NET data operations...");
            DataSet ds = new DataSet("MockDb");
            DataTable dt = new DataTable("Users");
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));

            dt.Rows.Add(101, "Amit");
            dt.Rows.Add(102, "Deepa");
            ds.Tables.Add(dt);

            foreach (DataRow row in ds.Tables["Users"].Rows)
            {
                Console.WriteLine($"Row -> ID: {row["Id"]}, Name: {row["Name"]}");
            }
        }

        static void DoubleScore(ref int val)
        {
            val *= 2;
        }

        static void CreateId(out int id)
        {
            id = new Random().Next(100, 999);
        }
    }
}