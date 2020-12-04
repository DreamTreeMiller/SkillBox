using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1522
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                throw new SomethingException("Какое-то сообщение", 10);

            }
            catch (SomethingException e) when (e.ErrorCode == 1)
            {
                Console.WriteLine($"{e.Message}. Код = {e.ErrorCode}"); // Действие 1
            }
            catch (SomethingException e) when (e.ErrorCode == 2)
            {
                Console.WriteLine($"Код = {e.ErrorCode}"); // Действие 2
            }
            catch (SomethingException e) when (e.ErrorCode == 8)
            {
                Console.WriteLine($"{e.Message}."); // Действие 3
            }
            catch (Exception e)
            {
                
            }

            #region docs throw

            // https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/throw

            #endregion
        }
    }
}
