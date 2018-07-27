using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class MySingletonClass
    {
        private static MySingletonClass _instance = null;

        // Default ctor.
        private MySingletonClass()
        {

        }

        // Check for single instance.
        public static MySingletonClass Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new MySingletonClass();
                }
                return _instance;
            }
        }

        public int Count { get; set; }

        public void ShowCount(string method)
        {
            Console.WriteLine($"{method}: Count is {Count}");
        }
    }
}
