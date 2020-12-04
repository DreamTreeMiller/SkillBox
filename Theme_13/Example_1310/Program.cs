using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1310
{
    class Program
    {
        static void Main(string[] args)
        {
            // Глубокое погружение в ООП ч.3
            // Ролик 1.Обобщения, параметризованные шаблоны
            // Ролик 2.Ограничения параметризованных типов
            // Ролик 3.Инвариантность, ковариантность и контравариантность
            // Ролик 4.Домашнее задание

            #region _

            MyClass o1 = new MyClass(); o1.MyProperty = 1;
            int i = Convert.ToInt32(o1.MyProperty);

            MyClass o2 = new MyClass(); o2.MyProperty = "Один";
            string s = Convert.ToString(o2.MyProperty);

            MyClass o3 = new MyClass(); o3.MyProperty = 1.0;
            double d = Convert.ToDouble(o2.MyProperty);

            #endregion
        }
    }
}
