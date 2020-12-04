using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1313
{
    class Program
    {
        //static void Swap(ref int A, ref int B) { int c = A; A = B; B = c; }
        //static void Swap(ref double[] A, ref double[] B) { double[] c = A; A = B; B = c; }
        //static void Swap(ref byte[] A, ref byte[] B) { byte[] c = A; A = B; B = c; }

        #region T

        static void Swap<T>(ref T A, ref T B) { T c = A; A = B; B = c; }

        #endregion

        static void Main(string[] args)
        {
            #region 

            int a = 1, b = 2;
            Console.WriteLine($"a = {a}  b = {b} ");
            Swap<int>(ref a, ref b);
            Console.WriteLine($"a = {a}  b = {b} "); Console.WriteLine();

            double[] x = { 1.1, 2.3, 4.5 };
            double[] y = { 6.7, 8.9, 10 };

            Console.Write("x: "); foreach (var e in x) Console.Write($"{e} "); Console.WriteLine();
            Console.Write("y: "); foreach (var e in y) Console.Write($"{e} "); Console.WriteLine();

            Swap<double[]>(ref x,ref  y);

            Console.Write("x: "); foreach (var e in x) Console.Write($"{e} "); Console.WriteLine();
            Console.Write("y: "); foreach (var e in y) Console.Write($"{e} "); Console.WriteLine(); Console.WriteLine();

            byte[] k = { 1, 2, 4 };
            byte[] l = { 6, 8, 10 };

            Console.Write("k: "); foreach (var e in k) Console.Write($"{e} "); Console.WriteLine();
            Console.Write("l: "); foreach (var e in l) Console.Write($"{e} "); Console.WriteLine();

            Swap<byte[]>(ref k, ref l);

            Console.Write("k: "); foreach (var e in k) Console.Write($"{e} "); Console.WriteLine();
            Console.Write("l: "); foreach (var e in l) Console.Write($"{e} "); Console.WriteLine();

            #endregion

            #region T

            Console.WriteLine("\n---\n");

            Swap<int>(ref a, ref b);
            Console.WriteLine($"a = {a}  b = {b} "); Console.WriteLine();

            Swap<byte[]>(ref k, ref l);
            Console.Write("k: "); foreach (var e in k) Console.Write($"{e} "); Console.WriteLine();
            Console.Write("l: "); foreach (var e in l) Console.Write($"{e} "); Console.WriteLine();



            #endregion

        }
    }
}
