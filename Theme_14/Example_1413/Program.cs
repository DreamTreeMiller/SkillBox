using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1413
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = ApiService.GetData();

            DataProcessing processing = new DataProcessing(data);

            OptionDataProcessing option = new OptionDataProcessing(Handlers.SaveToTextFile);
            processing.SetProcess(option);
            processing.ActionProcessing();

            Console.ReadKey();

            processing.SetProcess(Handlers.SaveToXmlFile);
            processing.ActionProcessing();

            Console.ReadKey();

            processing.SetProcess(Handlers.WriteToConsole);
            processing.ActionProcessing();

            Console.ReadKey();
        }
    }
}
