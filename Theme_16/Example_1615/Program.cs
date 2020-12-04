using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1615
{
    class Bag
    {
        public Bag(int i, string s, double d)
        {
            this.MyProperty1 = i;
            this.MyProperty2 = s;
            this.MyProperty3 = d;
        }

        public int MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
        public double MyProperty3 { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Print

            var pth1 = new ParameterizedThreadStart(
               o =>
               {
                   for (int i = 0; i < 10; i++)
                   {
                       Console.WriteLine(o);
                       Thread.Sleep(10);
                   }
               });

            Thread thread1 = new Thread(pth1);
            thread1.Start("+ ");

            #endregion

            #region PrintBag

            var pth2 = new ParameterizedThreadStart(
                o => 
                {
                    var b = o as Bag;
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine($"{b.MyProperty1} {b.MyProperty2} {b.MyProperty3}");
                        Thread.Sleep(10);
                    } 
                });

            Thread thread2 = new Thread(pth2);
            thread2.Start(new Bag(2019, "Курс С#", 20.08));

            #endregion
        }
    }
}