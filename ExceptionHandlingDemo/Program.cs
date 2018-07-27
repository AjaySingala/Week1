using System;

namespace ExceptionHandlingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //ExceptionDemo();
                ExceptionWithMessageDemo();
            }
            catch (CustomException cex)
            {
                Console.WriteLine($"Inside main(): {cex.Message}");
                //throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ExceptionDemo()
        {
            throw new CustomException();    // default ctor
        }

        static void ExceptionWithMessageDemo()
        {
            try
            {
                foo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Inside foo(). Exception: {ex.Message}");
                throw;
            }
        }

        static void foo()
        {
            throw new CustomException("This exception thrown by me.");
        }
    }
}
