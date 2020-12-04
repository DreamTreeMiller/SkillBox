using System.Collections.Generic;
 
using System.Text;
using System.Threading.Tasks;

namespace Example_1552
{

    class Program
    {
        static void Main(string[] args)
        {
            2.Pow(4).Print();

            List<int> vs = new List<int>();
            
            vs.Add(1);

            2.AddToList(vs);


            #region docs
            // https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/classes-and-structs/extension-methods

            // https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/classes-and-structs/extension-methods#general-guidelines
            #endregion

        }
    }
}
