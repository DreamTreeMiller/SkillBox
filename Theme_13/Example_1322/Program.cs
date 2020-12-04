using Example_1321;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1322
{

    class Class1<T>
        where T: new()
    {
        public T field;

        public Class1()
        {
            field = new T();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Class1<Worker> worker = new Class1<Worker>();
            Class1<Cat> kitty1 = new Class1<Cat>();
            
        }
    }
}
