using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "this is a sentence with all lower-case letters and a word in all CAPS.";
            int count = sentence.WordCount();
            
            Console.WriteLine($"{sentence}");
            Console.WriteLine($"Count: {count}");

            string myname = "Ajay Singala";
            Console.WriteLine($"{myname}");
            Console.WriteLine($"Count: {myname.WordCount()}");

            Customer c1 = new Customer();
            c1.Id = 111;
            c1.Firstname = "John";
            c1.Lastname = "Smith";

            Customer c2 = new Customer(120, "Mary", "Jane");

            //Customer c3 = new Customer("Neo");
            
            Customer c4 = new Customer()
            {
                Firstname = "Neo"
            };

            Customer cust = new Customer()
            {
                Id = 101,
                Firstname = "Ajay",
                Lastname = "Singala"
            };
            Console.WriteLine(cust.Fullname());
        }
    }
}
