using System;

namespace DesignPatterns.DependencyInjection
{
    // repository interface
    public interface ICustomerRepository
    {
        string GetCustomerName(int id);
    }

    // concrete database repository
    public class SqlCustomerRepository : ICustomerRepository
    {
        public string GetCustomerName(int id)
        {
            // query simulator
            return id == 1 ? "Deepa Nair" : "Unknown Customer";
        }
    }

    // service dependent on repository
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;

        // repository dependency injected through constructor
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public void PrintCustomer(int id)
        {
            string name = _repository.GetCustomerName(id);
            Console.WriteLine($"Customer Details: {name} (ID: {id})");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- dependency injection test ---");

            ICustomerRepository repo = new SqlCustomerRepository();
            CustomerService service = new CustomerService(repo);

            service.PrintCustomer(1);
        }
    }
}