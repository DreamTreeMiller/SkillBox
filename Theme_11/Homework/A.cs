using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    interface I1
    {
        void M();
    }

    interface I2
    {
        void M();
    }

    class A : I1, I2
    {
		void I1.M()
		{
			Console.WriteLine("A.I1.M()");
		}
		// вот так нельзя
		// virtual void I1.M() { }
        // говорит, что virtual недопустим для этго элелмента
        // тогда, получается, я не могу переопределить методы интерфейся в наследниках класса А

        void I2.M()
		{
            Console.WriteLine("A.I2.M()");
		}
        public virtual void M() 
        {
            Console.WriteLine("A.M()"); 
        
        } 
    }
    

    // если пишу так, то ругается
    //class B:A
    //{
    //    void I1.M() { Console.WriteLine("B.I1.M()"); }
    //    void I2.M() { Console.WriteLine("B.I2.M()"); }

    //    public override void M() { }
    //}

    // Если явно указываю, что класс В наследует интерфейсы I1 I2
    // тогда всё в порядке. 
    // Но тогда теряется смысл наследования реализации интерфейса в классе А !
    // В классе В надо заново явно указывать наследование от I1 I2, 
    // чтобы реализовать эти интерфейсы уже для калсса В
    class B : A, I1, I2
    {
        void I1.M() { Console.WriteLine("B.I1.M()"); }
        void I2.M() { Console.WriteLine("B.I2.M()"); }

        public override void M() { }
    }


}
