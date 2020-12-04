using System;
using System;
using System.Text;
using System.Threading;

namespace Example_1643_NET_Core3._0
{

    class Program
    {
        static Random random = new Random();
        static Matrix m = new Matrix();

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            m.matrixMenu();

        }
    }
}

