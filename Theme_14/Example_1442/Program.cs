using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1442
{
    class Program
    {
        static void Main(string[] args)
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            var factory = new Factory(10);
            var cars = factory.ToProduce();

            foreach (var item in cars) Console.WriteLine(item);

            #region _

            // события — с их помощью определяются методы, 
            // вызываемые автоматически при возникновении определенной ситуации, 
            // например при нажатии кнопки.

            // События нередко описываются как действия, которые происходят с объектом

            // События можно охарактеризовать и как способ обмена сообщениями между двумя объектами.


            // Замечание. Делегаты и события — одни из самых продвинутых функций языка C# 
            // и обучение им может занять некоторое время, поэтому не беспокойтесь, 
            // если сразу не поняли принцип их работы!
            // Прайс Марк Дж. 
            // C# 7 и .NET Core. Кросс - платформенная разработка для профессионалов. 
            // 3-е изд. — СПб.: Питер, 2018. — 640 с.: ил. — (Серия «Библиотека программиста»). стр. 219
            #endregion

        }
    }
}
