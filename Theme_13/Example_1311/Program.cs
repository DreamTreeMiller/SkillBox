using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1311
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 

            List<int> list = new List<int>();

            #endregion

            #region Temporary<Template>


            Temporary<double> t1 = new Temporary<double>(28.09); t1.GetPropertyInformation();
            Temporary<string> t2 = new Temporary<string>("value"); t2.GetPropertyInformation();
            Temporary<bool> t3 = new Temporary<bool>(false); t3.GetPropertyInformation();

            #endregion
        }
    }
}
