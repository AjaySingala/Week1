using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegatesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleDelegateDemo();
            //AnonymousDelegateDemo();
            LambdaDelegateDemo();
            //DelegateAndEventDemo();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER>...");
            Console.ReadLine();
        }

        // The simple delegate.
        public delegate string Reverse(string s);

        private static void SimpleDelegateDemo()
        {
            string line = "This is a string";
            Console.WriteLine("Simple Delegate Demo.");
            Reverse rev = ReverseString;
            Console.WriteLine(line);
            Console.WriteLine("Reversed =>");

            Console.WriteLine(rev(line));
        }

        static string ReverseString(string s)
        {
            var result = new string(s.Reverse().ToArray());
            return result;
        }

        private static void AnonymousDelegateDemo()
        {
            List<int> list = new List<int>();

            for (int i = 1; i <= 100; i++)
            {
                list.Add(i);
            }

            // Anon Delegate
            List<int> result = list.FindAll(
              delegate (int num)
              {
                  return (num % 2 == 0);
              }
            );

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void LambdaDelegateDemo()
        {
            List<int> list = new List<int>();

            for (int i = 1; i <= 100; i++)
            {
                list.Add(i);
            }

            // Lambda Expression OR just Lambda.
            // Core building block of LINQ
            // First introduced in C# 3.0.
            List<int> result = list.FindAll(i => i % 2 == 0);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void DelegateAndEventDemo()
        {
            // Subscribe to the event.
            Coffee coffee1 = new Coffee
            {
                Name = "Mocha",
                Bean = "Mocha",
                CountryOfOrigin = "Columbia",
                MinimumStockLevel = 4
            };
            coffee1.Buy(6);
            coffee1.OutOfBeans += CoffeeOrder_OutOfBeans;
            coffee1.OutOfBeans += SendEmail;

            #region Lambda Delegate Event Handler Subscribe

            //Coffee.OutOfBeansHandler handler = (o, e) =>
            //{
            //    Coffee c = o as Coffee;
            //    string coffeeBean = c.Bean;
            //    Console.WriteLine($"Have to order more {coffeeBean}...");
            //};

            //coffee1.OutOfBeans += handler;
            
            #endregion


            coffee1.MakeCoffee();   // 5
            coffee1.MakeCoffee();   // 4
            coffee1.MakeCoffee();   // 3 : trigger
            coffee1.MakeCoffee();   // 2 : trigger
            Unsubscribe(coffee1);
            
            #region Lambda Delegate Event Handler Unsubscribe

            //coffee1.OutOfBeans -= handler;
            
            #endregion

            coffee1.MakeCoffee();   // 1 no trigger
        }

        private static void SendEmail(Coffee sender, EventArgs args)
        {
            string coffeeBean = sender.Bean;
            Console.WriteLine($"Sending email to order more coffee for {coffeeBean}...");
            // Reorder the coffee bean.
        }

        private static void CoffeeOrder_OutOfBeans(Coffee sender, EventArgs args)
        {
            string coffeeBean = sender.Bean;
            Console.WriteLine($"Have to order more {coffeeBean}...");
            // Reorder the coffee bean.
        }

        private static void Unsubscribe(Coffee coffee)
        {
            coffee.OutOfBeans -= CoffeeOrder_OutOfBeans;
        }
    }
}
