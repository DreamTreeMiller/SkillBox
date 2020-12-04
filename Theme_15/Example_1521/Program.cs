using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1521
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Пример 1

            //try
            //{
            //    int[] arr = new int[10];

            //    Console.Write("Введите  arr[11]: ");

            //    arr[11] = Convert.ToInt32(Console.ReadLine());
            //}
            //catch (FormatException e)
            //{
            //    Console.WriteLine($"Ошибка ввода. e.Message = {e.Message}");
            //}
            //catch (IndexOutOfRangeException e)
            //{
            //    Console.WriteLine($"Ошибка индекса. e.Message = {e.Message}");
            //}


            #endregion

            #region Пример 2

            try
            {
                Class.Method();
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Ошибка ввода. e.Message = {e.Message}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Ошибка индекса. e.Message = {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Общщая ошибка. e.Message = {e.Message}");
            }


            #endregion



        }
    }
}
