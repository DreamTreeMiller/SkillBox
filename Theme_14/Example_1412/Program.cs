using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1412
{
    #region ToDo

    // void, void
    public delegate void DelegateName1();

    // void, string
    public delegate void DelegateName2(string Message);

    // double, double
    public delegate double DelegateName3(double Args);

    #endregion

    class Program
    {
        // void, void
        static void Something1() { Console.WriteLine("Something method"); }

        // void, string
        static void Something2(string Msg) { Console.WriteLine(Msg); }

        // double, double
        static double Something3(double X) { return X + 10; }

        static void Main(string[] args)
        {

            // var r1 = Something1;
            // var r2 = Something2;
            // var r3 = Something3;

            #region ToDo

            DelegateName1 delegateVariable1 = new DelegateName1(Something1);
            DelegateName2 delegateVariable2 = new DelegateName2(Something2);
            DelegateName3 delegateVariable3 = new DelegateName3(Something3);

            #region _


            Something1();


            DelegateName1 delegateVar1 = Something1;
            delegateVar1();

            DelegateName2 delegateVar2 = Something2;
            Something2("Строка");
            delegateVar2("Строка");

            DelegateName3 delegateVar3 = Something3;
            var res = Something3(2.5);
            res = delegateVar3(2.5);

            #endregion

            #endregion

            #region Определения

            // Определение 1. Делегат - "переменная", которая хранит в себе ссылку на метод

            // Определение 2. Сигнатура метода — тип, возвращаемый методом и список типов параметров, 
            //                которые могут быть переданы при вызове метода

            // https://stackoverflow.com/questions/8808703/method-signature-in-c-sharp

            // Определение 3. Делегат — это адрес метода в памяти,
            //                имеющего ту же сигнатуру, что и у делегата, позволяющий безопасно его вызывать

            #endregion

        }
    }
}
