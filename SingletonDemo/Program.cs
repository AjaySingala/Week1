using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MySingletonClass inst = MySingletonClass.Instance;
            inst.Count++;
            inst.ShowCount("Main()");
            foo(inst);
            inst.ShowCount("Main()");

            MySingletonClass newInstance = MySingletonClass.Instance;
            newInstance.ShowCount("Main() -> newInstance");

        }

        static void foo(MySingletonClass localInst)
        {
            localInst.ShowCount("foo()");
            localInst.Count += 25;
        }
    }
}
