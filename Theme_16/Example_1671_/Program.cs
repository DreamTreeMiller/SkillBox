using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1671
{


    class Provired
    {
        Stack<int> data = new Stack<int>();

        public void Add(int a)
        {
            data.Push(a);
        }

        public int Peek()
        {
            return data.Count == 0 ? 0 : data.Peek() + 1;
        }

        public void Print()
        {
            foreach (var e in data) Console.Write($"{e} ");
            Console.WriteLine("----");
        }
    }



    class Program
    {
        
        static void Change(object o)
        {
            var d = o as Provired;
            int r = d.Peek();
            d.Add(r);
        }

      
        static void Main(string[] args)
        {

            Provired  provired = new Provired ();
            provired.Print();



            //Change(provired); provired.Print();
            //Change(provired); provired.Print();
            //Change(provired); provired.Print();

            Console.WriteLine("\n====\n");
            Random r = new Random();
            Thread[] threads = new Thread[10];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(Change));
                Thread.Sleep(r.Next(10, 50));
                threads[i].Start(provired);
            }
            
            int time = 10;

            for (int i = 0; i < time; i++)
            {
                Console.WriteLine($"Данные будут через {time - i} сек.");
                Thread.Sleep(1000);
            }

            provired.Print();

            Console.ReadLine();
        }
    }
}
