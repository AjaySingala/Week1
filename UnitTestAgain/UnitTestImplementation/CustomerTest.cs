using System;
using Xunit;

using UnitTestLibrary;

namespace UnitTestImplementation
{
    public class CustomerTest
    {
        [Fact]
        public void InvoiceAmount_With10Discount()
        {
            // Arrange.
            Customer c = new Customer();
            
            c.Id = 101;
            c.Firstname = "Ajay";
            c.Lastname = "Singala";
            c.Quantity = 15;
            c.Amount = 100;

            var expected = 95;            
            // Act.
            var result = c.CalculateInvoiceAmount();

            // Assert.
            Assert.Equal(expected, result);
            
        }

        [Fact]
        public void FullName_ReturnsFullName()
        {
            // Arrange.
            Customer c = new Customer();
            c.Id = 101;
            c.Firstname = "Ajay";
            c.Lastname = "Singala";
            c.Quantity = 8;
            c.Amount = 100;

            var expected = "Singala, Ajay";            
            // Act.
            var result = c.FullName();

            // Assert.
            Assert.Equal(expected, result);
        }
    }
}
