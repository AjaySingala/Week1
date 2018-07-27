using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueRefTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //PassByValueDemo();
            //PassByRefDemo();
            //StringsDemo();
            ObjectsDemo();
            //ArrayDemo();
            BoxingAndUnBoxing();

            Console.WriteLine("\nPress <ENTER>...");
            Console.ReadLine();
        }

        private static void BoxingAndUnBoxing()
        {
            // Implicit boxing process!
            // To box a variable, you assign it to an object reference
            int i = 100;
            object o = i;
            Console.WriteLine($"i = {i} and o = {o}");

            // The process of converting a reference type to a value type is called unboxing
            // When you assign an object reference to a value type.
            // Unlike the boxing process, to unbox a value type you must explicitly 
            // cast the variable back to its original type.
            int j;
            j = (int)o;
            Console.WriteLine($"i = {i} and j = {j} and o = {o}");
        }

        private static void ArrayDemo()
        {
            int[] i = new int[] { 10, 5 };
            int[] j = new int[] { 20, 25 };
            int[] k = new int[] { 30, 35 };

            SwitchColor("Before");
            for (int a = 0; a < i.Length; a++)
            {
                Console.WriteLine($"i[{a}] = {i[a]}");
                Console.WriteLine($"\tj[{a}] = {j[a]}");
                Console.WriteLine($"\t\tk[{a}] = {k[a]}");
            }

            i = k;

            SwitchColor("After...");
            for (int a = 0; a < i.Length; a++)
            {
                Console.WriteLine($"i[{a}] = {i[a]}");
                Console.WriteLine($"\tj[{a}] = {j[a]}");
                Console.WriteLine($"\t\tk[{a}] = {k[a]}");
            }

            Console.WriteLine("Before sorting");
            int[] nums = new int[] { 10, 2, 5, 8, 1 };
            for (int a = 0; a < nums.Length; a++)
            {
                Console.WriteLine($"nums[{a}] = {nums[a]}");
            }

            Console.WriteLine("After sorting");
            for(int o = 0; o < nums.Length - 1; o++)
            {
                

            }
            for (int a = 0; a < nums.Length; a++)
            {
                Console.WriteLine($"nums[{a}] = {nums[a]}");
            }

            Console.WriteLine("Before sorting");
            int[] numbers = new int[] { 10, 2, 5, 8, 1 };
            for (int a = 0; a < numbers.Length; a++)
            {
                Console.WriteLine($"numbers[{a}] = {numbers[a]}");
            }

            Console.WriteLine("After sorting");
            Array.Sort(numbers);
            for (int a = 0; a < numbers.Length; a++)
            {
                Console.WriteLine($"numbers[{a}] = {numbers[a]}");
            }
        }

        private static void ObjectsDemo()
        {
            Customer c1 = new Customer { Id = 101, Name = "Ajay" };
            Customer c2 = new Customer { Id = 102, Name = "John" };
            Customer c3 = c1;
            Customer c4 = new Customer { Id = 103, Name = "Mary" };

            Console.WriteLine($"c1 = {c1.Name}, c2 = {c2.Name}, c3 = {c3.Name}, c4 = {c4.Name}");

            c2 = c4;

            Console.WriteLine($"c1 = {c1.Name}, c2 = {c2.Name}, c3 = {c3.Name}, c4 = {c4.Name}");

            StructAndClass();
        }

        struct MyStruct
        {
            public int Contents;
        }

        class MyClass
        {
            public int Contents = 0;
        }

        private static void StructAndClass()
        {
            MyStruct struct1 = new MyStruct();
            MyStruct struct2 = struct1;
            struct2.Contents = 125;

            MyClass class1 = new MyClass();
            MyClass class2 = class1;
            class2.Contents = 165;

            Console.WriteLine($"Value Types: {struct1.Contents} and {struct2.Contents}");
            Console.WriteLine($"Reference Types: {class1.Contents} and {class2.Contents}");
        }

        private static void StringsDemo()
        {
            string s1 = "Ajay";
            string s2 = "Singala";
            string s3 = s1;
            Console.WriteLine($"s1 = {s1}, s2 = {s2}, s3 = {s3}");

            s1 = "John";
            Console.WriteLine($"s1 = {s1}, s2 = {s2}, s3 = {s3}");
        }

        private static void PassByRefDemo()
        {
            int[] i = new int[] { 10, 5 };
            int[] j = new int[] { 20, 25 };

            SwitchColor("Before");
            for (int a = 0; a < i.Length; a++)
            {
                Console.WriteLine($"i[{a}] = {i[a]}");
                Console.WriteLine($"\tj[{a}] = {j[a]}");
            }

            SwapArray(i, j);
            //SwapArray(ref i, ref j);

            SwitchColor("After...");
            for (int a = 0; a < i.Length; a++)
            {
                Console.WriteLine($"i[{a}] = {i[a]}");
                Console.WriteLine($"\tj[{a}] = {j[a]}");
            }
        }

        private static void SwapArray(int[] x, int[] y)
        //private static void SwapArray(ref int[] x, ref int[] y)
        {
            SwitchColor("\t\tSwapping Arrays...");
            SwitchColor("\t\tBefore...");
            for (int a = 0; a < x.Length; a++)
            {
                Console.WriteLine($"\t\tx[{a}] = {x[a]}");
                Console.WriteLine($"\t\t\ty[{a}] = {y[a]}");
            }

            int[] z = x;
            x = y;
            y = z;

            SwitchColor("\t\tAfter...");
            for (int a = 0; a < x.Length; a++)
            {
                Console.WriteLine($"\t\tx[{a}] = {x[a]}");
                Console.WriteLine($"\t\t\ty[{a}] = {y[a]}");
            }
        }

        private static void PassByValueDemo()
        {
            int i = 10;
            int j = 5;
            SwitchColor("Before");
            Console.WriteLine($"i = {i}, j = {j}");
            Swap(i, j);
            SwitchColor("After");
            Console.WriteLine($"i = {i}, j = {j}");
        }

        private static void Swap(int x, int y)
        {
            SwitchColor("\tSwapping Values...");
            int z = x;
            SwitchColor("\tBefore");
            Console.WriteLine($"\tx = {x}, y = {y}, z = {z}");
            x = y;
            y = z;
            SwitchColor("\tAfter");
            Console.WriteLine($"\tx = {x}, y = {y}, z = {z}");
        }

        private static void SwitchColor(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine($"{message}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

        }
    }
}
