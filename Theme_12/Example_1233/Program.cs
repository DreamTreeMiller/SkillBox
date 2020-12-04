using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1233
{
    static class StaticClass
    {
        static StaticClass()
        {
            Console.WriteLine("Первое обращение к StaticClass");
            id = 0;
        }

        static int id;

        public static int Id { get { return id; } set { id = value; } }

        static public void SetId(int value)
        {
            id = value;
        }

        public static int GetId()
        {
            return id;
        }

        public static new string ToString()
        {
            return $"Id = {id}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;

            //Math
            StaticClass.Id = 300;


            Console.WriteLine(StaticClass.Id);


            StaticClass.SetId(100);

            Console.WriteLine(StaticClass.GetId());


            Console.WriteLine(StaticClass.ToString());
        }
    }
}
