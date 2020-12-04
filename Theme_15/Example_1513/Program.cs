using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1513
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] arr = new int[10];

                Console.Write("Введите  arr[11]: ");

                arr[11] = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Ошибка ввода. e.Message = {e.Message}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Ошибка индекса. e.Message = {e.Message}");
            }

        }
    }
}
