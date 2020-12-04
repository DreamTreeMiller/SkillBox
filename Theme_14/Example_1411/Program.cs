using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

/// Тема. Делегаты
/// Ролик 1. Общие понятия
/// Ролик 2. Обобщённые делегаты
/// Ролик 3. Анонимные методы и лямбда-выражения
/// Ролик 4. События и событийно-управляемая модель
/// Ролик 5. Пример использования событий при соделировании социальной сети
/// Ролик 6. Одно событие из WPF
/// Ролик 7. Домашнее задание



namespace Example_1411
{
    class Program
    {
        static List<Worker> GetWorkers(int Count = 10)
        {
            var t = new List<Worker>();
            Random r = new Random();
            for (int i = 0; i < Count; i++)
            {
                t.Add(new Worker($"Имя_{i + 1}", $"Фамилия_{i + 1}", r.Next(18, 70), r.Next(20000, 30000)));
            }
            return t;

        }

        

        static void Main(string[] args)
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;

            List<Worker> storage = GetWorkers();
            foreach (var item in storage) Console.WriteLine(item);

            Console.WriteLine();



            Predicate<Worker> search = new Predicate<Worker>(Search);

            var findsWorker = storage.FindAll(search);

            findsWorker = storage.FindAll(delegate (Worker obj)
            {
                return obj.Age > 40;
            });

            findsWorker = storage.FindAll((Worker obj) =>
            {
                return obj.Age > 40;
            });

            findsWorker = storage.FindAll((obj) =>
            {
                return obj.Age > 40;
            });

            findsWorker = storage.FindAll(obj =>
            {
                return obj.Age > 40;
            });

            findsWorker = storage.FindAll(obj => obj.Age > 40);

            findsWorker = storage.FindAll(e => e.Age > 40);


            // List<T>.FindAll(Predicate <T> match);
            // var findsWorker = storage.FindAll(???);

            foreach (var item in findsWorker) Console.WriteLine(item);


        }

        private static bool Search(Worker obj)
        {
            return obj.Age > 40;
        }
    }
}
