using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1512
{
    class Program
    {
        #region Пример 4

        /// <summary>
        /// Пытается преобразовать строку в число
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <param name="number">число</param>
        /// <returns>Результат преобразования</returns>
        static bool TryParse(string input, out int number)
        {
            try
            {
                number = Convert.ToInt32(input);
                return true;
            }
            catch
            {
                number = default;
                return false;
            }
        }

        #endregion

		static int MyParse(string s)
		{
			return MyParse1(s);
		}

		static int MyParse1(string s)
		{
			return MyParse2(s);
		}

		static int MyParse2(string s)
		{
			return int.Parse(s);
		}

        static void Main(string[] args)
        {
			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
			// Ролик 1. Обработка исключений

			#region Пример 1-5

			#region Пример 1

			//Console.Write("Введите n: ");
			//string s1 = Console.ReadLine();
			//int n = int.Parse(s1);
			//Console.WriteLine($"Всё хорошо, n = {n}");

			//int k;

			//Console.Write("Введите k: ");
			//string s1 = Console.ReadLine();
			//bool flag = int.TryParse(s1, out k);
			//Console.WriteLine(flag ? $"Всё хорошо, k = {k}" : $"Всё плохо k = {k}");

			#endregion

			#region Пример 2

			//int l;

			//try
			//{
			//    Console.Write("Введите l: ");
			//    string s2 = Console.ReadLine();
			//    l = int.Parse(s2);
			//    Console.WriteLine($"Всё хорошо, l = {l}");
			//}
			//catch
			//{
			//    l = 0;
			//    Console.WriteLine($"Всё плохо, l = {l}");
			//}

			#endregion

			#region Пример 3

			//int h;
			//Console.Write("Введите h: ");
			//string s3 = Console.ReadLine();
			//try
			//{
			//	h = MyParse(s3);
			//	Console.WriteLine($"Всё хорошо, h = {h}");
			//}
			//catch(Exception e)
			//{
			//	h = 0;
			//	Console.WriteLine($"Всё плохо, h = {h}");
			//	Console.WriteLine("Exception number");
			//	Console.WriteLine(e.HResult);
			//	Console.WriteLine("Название исключения");
			//	Console.WriteLine(e.Message);
			//	Console.WriteLine("e.Source");
			//	Console.WriteLine(e.Source);
			//	Console.WriteLine("e.StackTrace");
			//	Console.WriteLine(e.StackTrace);
			//	Console.WriteLine("TargetSite");
			//	Console.WriteLine(e.TargetSite);
			//	Console.WriteLine("Help link");
			//	Console.WriteLine(e.HelpLink);
			//}

			#endregion

			#region Пример 4

			//Console.Write("Введите t: ");
			//string s4 = Console.ReadLine();
			//int t;
			//bool f = TryParse(s4, out t);

			//Console.WriteLine(f ? $"Всё хорошо, t = {t}" : $"Всё плохо t = {t}");

			#endregion

			#region Пример 5

			//try
			//{
			//	int[] arr = new int[10];
			//	arr[11] = 1;
			//}
			//catch
			//{
			//	Console.WriteLine("Ошибка");
			//}


			#endregion

			#endregion

			#region Пример 6

			//try
			//{
			//    int[] arr = new int[10];

			//    Console.Write("Введите  arr[11]: ");

			//    arr[11] = Convert.ToInt32(Console.ReadLine());
			//}
			//catch
			//{
			//    Console.WriteLine("Ошибка");
			//}

			#endregion

			#region Пример 7

				//try
				//{
				//	int[] arr = new int[10];

				//	Console.Write("Введите  arr[11]: ");

				//	arr[11] = Convert.ToInt32(Console.ReadLine());
				//}
				//catch (FormatException)
				//{
				//	Console.WriteLine("Ошибка  ");
				//}
				//catch (IndexOutOfRangeException)
				//{
				//	Console.WriteLine("Ошибка индекса");
				//}
				//catch (Exception ex)
				//{
				//	Console.WriteLine($"Иная ошибка ");
				//}

			#endregion

			#region  from MSDN
			try
			{
				// TryCast produces an unhandled exception.
				TryCast();
			}
			catch (Exception ex)
			{
				// Catch the exception that is unhandled in TryCast.
				Console.WriteLine
					("Catching the {0} exception triggers the finally block.",
					ex.GetType());

				// Restore the original unhandled exception. You might not
				// know what exception to expect, or how to handle it, so pass
				// it on.
				throw;
			}
			//finally
			//{
			//	Console.WriteLine("finally after throw in catch");
			//}
			#endregion

			#region docs try-catch
			//https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/try-catch
			#endregion

			#region docs Exception
			//https://docs.microsoft.com/ru-ru/dotnet/api/system.exception?view=netframework-4.8
			#endregion
		}

		public static void TryCast()
		{
			int a = 123;
			string s = "Some string";
			object obj = s;

			try
			{
				// Invalid conversion; obj contains a string, not a numeric type.
				a = (int)obj;

				// The following statement is not run.
				Console.WriteLine("WriteLine at the end of the try block.");
			}
			finally
			{
				// Report that the finally block is run, and show that the value of
				// i has not been changed.
				Console.WriteLine("\nIn the finally block in TryCast, i = {0}.\n", a);
			}
		}
	}
}
