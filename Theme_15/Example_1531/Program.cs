using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1531
{


    class MyClass
    {
        public int MyProperty { get; set; }

        public static MyClass operator +(MyClass x, MyClass y)
        {
            return new MyClass() { MyProperty = x.MyProperty + y.MyProperty };
        }

        public static string operator -(MyClass x, MyClass y)
        {
            return "Минус";
        }


        public static string operator *(MyClass x, Complex y)
        {
            return "Минус";
        }



    }

    class Program
    {
        static void Main(string[] args)
        {


            MyClass a = new MyClass() { MyProperty = 10 }; Console.WriteLine(a.MyProperty);
            MyClass b = new MyClass() { MyProperty = 20 }; Console.WriteLine(b.MyProperty);

            MyClass res = a + b; Console.WriteLine(res.MyProperty);
            //a = a + b;
            //a += b;
            Console.WriteLine();

            Complex k = new Complex() { A = 1, B = 2 };
            Console.WriteLine(k);
            Complex l = new Complex() { A = 3, B = 4 };
            Console.WriteLine(l);

            Complex r = k + l;
            Console.WriteLine(r);

            Console.WriteLine(k > l);


            string s = k * a ; Console.WriteLine(res.MyProperty);

        }
    }
}
