using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1324
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage1<A> storage1 = new Storage1<A>();
            // Storage1<B> storage = new Storage1<B>(); // Ошибка 

            Storage2<B> storage2 = new Storage2<B>();
            //Storage2<C> storage = new Storage2<C>(); // Ошибка 

            Storage3<C> storage3 = new Storage3<C>();
            // Storage3<D> storage = new Storage3<D>(); // Ошибк

            Storage5<E> storage5 = new Storage5<E>();
            // Storage5<D> storage = new Storage5<D>(); // Ошибк
            // Storage5<C> storage = new Storage5<C>(); // Ошибк



        }
    }
}
