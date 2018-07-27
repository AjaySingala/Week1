using System;

namespace UnitTestLibrary
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public int Quantity { get; set; }
        public double Amount { get; set; }

        private double _netAmount;

        public string FullName()
        {
            var name = $"{Lastname}, {Firstname}";
            return name;
        }

        public double CalculateInvoiceAmount()
        {
            double discount;
            if(Quantity > 10)
            {
                discount = (Amount * 5) / 100;
            }
            else
            {
                discount = (Amount * 1) / 100;
            }
            _netAmount = Amount - discount;

            return _netAmount;
        }
    }
}
