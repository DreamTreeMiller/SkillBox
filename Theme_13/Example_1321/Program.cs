using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1321
{

    #region _

    class Class1<T>
        where T : class
    {
        public T Field;
    }

    class Class2<T>
        where T : struct
    {
        public T Field;
    }

    #endregion



    class Program
    {
        static void Main(string[] args)
        {

            Class1<Cat> kitty1 = new Class1<Cat>();
            Class1<string> strings1 = new Class1<string>();
            Class1<Worker> worker1 = new Class1<Worker>();
            Class1<double> number1 = new Class1<double>();

            Class2<Cat> kitty2 = new Class2<Cat>();
            Class2<string> strings2 = new Class2<string>();

            Class2<Worker> worker2 = new Class2<Worker>();
            Class2<double> number2 = new Class2<double>();


        }
    }
}
