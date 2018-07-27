using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegatesDemo
{
    public class Coffee
    {
        int _currentStockLevel;

        public EventArgs e = null;
        
        public delegate void OutOfBeansHandler(Coffee coffee, EventArgs args);
        public event OutOfBeansHandler OutOfBeans;

        public string Name { get; set; }
        public string Bean { get; set; }
        public string CountryOfOrigin { get; set; }
        public int MinimumStockLevel { get; set; }

        public void Buy(int quantity)
        {
            _currentStockLevel += quantity;
            Console.WriteLine($"Current Stock Level of {Bean}: {_currentStockLevel}");
        }

        public void MakeCoffee()
        {
            // Decrement stock level.
            _currentStockLevel--;
            Console.WriteLine($"Current Stock Level of {Bean}: {_currentStockLevel}");

            // If stock level drops below minimum, raise the event.
            if(_currentStockLevel < MinimumStockLevel)
            {
                // Check whether the event is null (no subscribers)
                if (OutOfBeans != null)
                {
                    // Raise the event.
                    OutOfBeans(this, e);
                }

                // New Simplified way of Delegate invokation:
                ////OutOfBeans?.Invoke(this, e);
            }
        }
    }
}
