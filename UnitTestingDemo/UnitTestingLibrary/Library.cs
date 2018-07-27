using System;

namespace UnitTestingLibrary
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Library
    {
        public bool foo(int id, string name)
        {
            return true;
        }
        
        public Customer GetCustomer(int id)
        {
            if(id == 0)
                return null;

            Customer customer = new Customer()
            {
                Id = id,
                Name = "Ajay Singala"
            };

            return customer;
        }
        public bool IsOdd(int number)
        {
            return number % 2 == 1;
        }

        public string Fullname(string firstName, string lastName)
        {
            return firstName + " " + lastName;
        }

        public int Divide(int a, int b)
        {
            return a / b;
        }

    }
}
