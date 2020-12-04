using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1551
{
    public static class Ext
    {
        public static void Print<T>(this T O)
        {
            Console.WriteLine(O);
        }

        public static void Print<T>(this List<T> O)
        {
            foreach (var e in O)
            {
                Console.Write($"{e} ");
            }
            Console.WriteLine();
        }

        static public int Pow(this int A, int B)
        {
            return (int)Math.Pow(A, B);
        }

        static public void AddTo<U>(this U item, List<U> Col)
            where U:struct
        {
            Col.Add(item);
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {

            List<int> d = new List<int>() { 1,2,3,4,5,6};
            d.Print();

            Console.ReadLine();
            int a=0;
            a.Print();
            2.Pow(4).AddTo(d);

            Console.WriteLine();

            d.Print();
            string s = "qwe";

            //List<string> vs = new List<string>();

            //s.AddTo(vs);



            //2.Pow(4).Print();

        }
    }
}
