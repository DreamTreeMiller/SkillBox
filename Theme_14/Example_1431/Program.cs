using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1431
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = ApiService.GetData();

            DataProcessing processing = new DataProcessing(data);

            // processing.SetProcess(TestMethod);

            //processing.SetProcess(delegate(string Msg)
            //{
            //    Console.WriteLine(Msg);
            //    System.IO.File.WriteAllText("test.txt", Msg);
            //});

            //processing.SetProcess((string Msg) =>
            //{
            //    Console.WriteLine(Msg);
            //    System.IO.File.WriteAllText("test.txt", Msg);
            //});

            //processing.SetProcess(Msg =>
            //{
            //    Console.WriteLine(Msg);
            //    System.IO.File.WriteAllText("test.txt", Msg);
            //});

            //processing.SetProcess(e =>
            //{
            //    Console.WriteLine(e);
            //    System.IO.File.WriteAllText("test.txt", e);
            //});

            processing.SetProcess(e => Console.WriteLine(e));
            processing.ActionProcessing();

            processing.SetProcess(e => File.WriteAllText("test123.txt", e));
            processing.ActionProcessing();



            Console.ReadKey();
        }


        static void TestMethod(string Msg)
        {
            Console.WriteLine(Msg);
            System.IO.File.WriteAllText("test.txt", Msg);
        }
    }
}
