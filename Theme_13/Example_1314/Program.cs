using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1314
{
    class Program
    {
        static void Main(string[] args)
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            // int
            Repository<int> ints = new Repository<int>();

            ints.Push(9); ints.Push(0); ints.Push(2);
            ints.Push(8); ints.Push(0); ints.Push(9);
            
            for (int i = 0; i < ints.Count; i++) Console.Write($"{ints[i]} "); 
            Console.WriteLine($"\nints.Count = {ints.Count}\n");

            while (ints.Count != 0) Console.Write($"{ints.Pop()} ");
            Console.WriteLine($"\nints.Count = {ints.Count}\n");

            // Worker
            Repository<Worker> workers = new Repository<Worker>();

            for (int i = 1; i <= 5; i++) workers.Push(new Worker($"Имя_{i}", $"Фамилия_{i}", 20 + i, i * 5000));

            for (int i = 0; i < workers.Count; i++) Console.WriteLine($"{workers[i]} "); Console.WriteLine();
            Console.WriteLine($"\nworkers.Count = {workers.Count}\n");

            while (workers.Count != 0) Console.WriteLine($"{workers.Pop()} ");
            Console.WriteLine($"\nworkers.Count = {workers.Count}\n");

        }
    }
}
