using System;

namespace ExceptionHandlingDemo
{
    public class CustomException : Exception
    {
       public CustomException() :
            base("My Custom Exception occurred.")
       {
       }

       public CustomException(string message) :
            base(message)
       {
       }
    }
}
