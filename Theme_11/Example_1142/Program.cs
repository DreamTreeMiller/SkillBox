using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1142
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            Console.WriteLine("A a = new A(); a.M();  "); a.M();

            B b = new B();
            Console.WriteLine("B b = new B(); b.M();  "); b.M();

            a = new B();
            Console.WriteLine("A a = new B(); a.M();  "); a.M();


            #region _

            Console.ReadKey();
            Console.WriteLine();
            C c = new C();
            Console.WriteLine("C c = new C(); c.M();  "); c.M();

            D d = new D();
            Console.WriteLine("D d = new D() d.M();  ");  d.M();

            c = new D();
            Console.WriteLine("c = new D(); c.M();  "); c.M();

            #endregion

        }
    }
}
