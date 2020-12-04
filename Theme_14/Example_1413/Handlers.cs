using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Example_1413
{
    static class Handlers
    {
        public static void SaveToTextFile(string DataSource)
        {
            System.IO.File.WriteAllText("file.txt", DataSource);
            Debug.WriteLine("Данные сохранены в файл file.txt");
        }

        public static void WriteToConsole(string DataSource)
        {
            Console.WriteLine(DataSource);
            Debug.WriteLine("Данные выведены в консоль");
        }

        public static void SaveToXmlFile(string DataSource)
        {
            new XElement("Data", DataSource).Save("data.xml");
            Debug.WriteLine("Данные сохранены в файл data.xml");
        }
    }
}
