using System;
using Xunit;

namespace UnitTestingLibrary.Tests
{
    public class TestingService
    {
        [Fact]
        public void FullName_ReturnsFullName()
        {
            // Arrange.
            string expected = "Ajay Singala";
            Library sh = new Library();

            // Act.
            string result = sh.Fullname("Ajay", "Singala");

            // Assert.
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FullName_PassNothing()
        {
            // Arrange.
            string expected = "";
            Library sh = new Library();

            // Act.
            string result = sh.Fullname("", "");

            // Assert.
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(22)]
        public void DetermineOddOrEven(int number)
        {
            // Arrange.
            Library lib = new Library();
            var expected = true;

            // Act.
            var result = lib.IsOdd(number);
            // Assert.
            Assert.Equal(expected, result);

            //Assert.True(IsOdd(number));
        }

        // private bool IsOdd(int number)
        // {
        //     return number % 2 == 1;
        // }


        [Fact]
        public void GetCustomer_ReturnsCustomer()
        {
            // Arrange
            Library lib = new Library();
            
            // Act.
            var cust = lib.GetCustomer(10);

            // Assert.
            Assert.IsType<Customer>(cust);
        }

        [Theory]
        [InlineData(1, "Ajay")]
        [InlineData(2, "John")]
        public void TestFoo(int id, string s)
        {
            // Arrange
            Library lib = new Library();
            
            // Act.
            var result = lib.foo(id, s);

            // Assert.
            Assert.True(result);
            
        }

        [Theory]
        [InlineData(0)]
        //[InlineData(2)]
        public void GetCustomer_ReturnsNull(int id)
        {
            // Arrange
            Library lib = new Library();
            
            // Act.
            var cust = lib.GetCustomer(id);

            // Assert.
            Assert.Equal(null, cust);
        }
    }
}
