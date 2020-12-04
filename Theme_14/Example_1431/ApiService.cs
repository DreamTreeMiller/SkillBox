using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1431
{
    class ApiService
    {
        public static string GetData()
        {
            string t = String.Empty;
            for (int i = 0; i < 10; i++)
            {
                t += Guid.NewGuid().ToString();
            }
            return t;
        }
    }
}
