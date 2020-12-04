using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1312
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 

            Dictionary<int, string> dic = new Dictionary<int, string>();

            #endregion

            #region Temporary<T, U>


            Temporary<double, int> t1 = new Temporary<double, int>(28.09, 1990); t1.GetPropertyInformation();
            Temporary<string, bool> t2 = new Temporary<string, bool>("value", false); t2.GetPropertyInformation();
            Temporary<bool, double> t3 = new Temporary<bool, double>(false, 22.33); t3.GetPropertyInformation();

            #endregion
        }
    }
}
