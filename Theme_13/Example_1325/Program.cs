using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1325
{

    class A { }
    class B : A{ }
    class C : A { }
    class D : A { }
    class E : B { }

    class MyClass<T1, T2, T3>
        where T1 : T2
        where T3 : T1
    {

    }

    class Program
    {
        static void Main(string[] args)
        {

            MyClass<B, A, E> my = new MyClass<B, A, E>();
            //MyClass<C, A, A> myClass1 = new MyClass<C, A, A>();
            //MyClass<E, A, A> myClass2 = new MyClass<E, A, A>();
            //MyClass<E, B, C> myClass3 = new MyClass<E, B, C>();

            //MyClass<string, object, int> myClass4 = new MyClass<string, object, int>();
            //MyClass<int, object, int> myClass5 = new MyClass<int, object, int>();
            //MyClass<int, ValueType, int> myClass6 = new MyClass<int, ValueType, int>();
            //MyClass<ValueType, object, int> myClass7 = new MyClass<ValueType, object, int>();

        }
    }
}
