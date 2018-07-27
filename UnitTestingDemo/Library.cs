using System;

namespace UnitTestingLibrary
{
    public class Library
    {
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
