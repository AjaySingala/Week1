using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //BinarySerDemo();
            XmlSerDemo();

            Console.WriteLine("Press <ENTER>...");
            Console.ReadLine();
        }

        static void BinarySerDemo()
        {
            Console.WriteLine();
            Console.WriteLine("Binary Serialization Demo BEGIN...");

            Customer customer = new Customer
            {
                Id = 101,
                FirstName = "Ajay",
                LastName = "Singala"
            };

            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer.LastName);

            Customer newCustomer = BinarySerialization(customer);

            Console.WriteLine();
            Console.WriteLine(newCustomer.Id);
            Console.WriteLine(newCustomer.FirstName);
            Console.WriteLine(newCustomer.LastName);

            Console.WriteLine();
            Console.WriteLine("Binary Serialization Demo END...");
        }

        static void XmlSerDemo()
        {
            Console.WriteLine();
            Console.WriteLine("XML Serialization Demo BEGIN...");
            Customer customer = new Customer
            {
                Id = 101,
                FirstName = "Ajay",
                LastName = "Singala"
            };

            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer.LastName);

            Customer newCustomer = XmlSerialization(customer);

            Console.WriteLine();
            Console.WriteLine(newCustomer.Id);
            Console.WriteLine(newCustomer.FirstName);
            Console.WriteLine(newCustomer.LastName);

            Console.WriteLine();
            Console.WriteLine("XML Serialization Demo END...");
        }

        static Customer BinarySerialization(Customer customer)
        {
            IFormatter formatter = new BinaryFormatter();

            // Write to file.
            Console.WriteLine();
            Console.WriteLine("Serializing...");
            Stream streamWrite = new FileStream(@"D:\Temp\Customer.txt", 
                FileMode.Create, FileAccess.Write);

            formatter.Serialize(streamWrite, customer);
            streamWrite.Close();
            Console.WriteLine("Serializing...Done!");

            // Read from file.
            Console.WriteLine();
            Console.WriteLine("Deserializing...");
            Stream streamRead = new FileStream(@"D:\Temp\Customer.txt", FileMode.Open, 
                FileAccess.Read);
            Customer newCustomer = (Customer)formatter.Deserialize(streamRead);
            streamRead.Close();
            Console.WriteLine("Deserializing...Done!");

            return newCustomer;
        }

        static Customer XmlSerialization(Customer customer)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Customer));

            // Write to file.
            Console.WriteLine();
            Console.WriteLine("Serializing...");
            Stream streamWrite = new FileStream(@"D:\Temp\Customer.xml", 
                FileMode.Create, FileAccess.Write);

            ser.Serialize(streamWrite, customer);
            streamWrite.Close();
            Console.WriteLine("Serializing...Done!");

            // Read from file.
            Console.WriteLine();
            Console.WriteLine("Deserializing...");
            Stream streamRead = new FileStream(@"D:\Temp\Customer.xml", 
            FileMode.Open, FileAccess.Read);
            Customer newCustomer = (Customer)ser.Deserialize(streamRead);
            streamRead.Close();
            Console.WriteLine("Deserializing...Done!");

            return newCustomer;
        }
    }
}
