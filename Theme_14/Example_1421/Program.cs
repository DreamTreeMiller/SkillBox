using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1421
{
    class Program
    {
        delegate void VoidDelegate1();
        public static void Void1() { }

        delegate void VoidDelegate2(int Argument1);
        public static void Void2(int Args1) { }

        delegate void VoidDelegate3(double Argument1);
        public static void Void3(double Args1) { }

        delegate void VoidDelegate4(string Argument1);
        public static void Void4(string Args1) { }

        delegate void VoidDelegate5(int Argument1, double Argument2);
        public static void Void5(int Args1, double Args2) { }

        delegate void VoidDelegate51(double Argument2, int Argument1);
        public static void Void51(double Args2, int Args1) { }

        delegate void VoidDelegate6(int Argument1, double Argument2, string Argument3);
        public static void Void6(int Args1, double Args2, string Args3) { }

        delegate void VoidDelegate7(string Argument1, double Argument2, int Argument3);
        public static void Void7(string Args1, double Args2, int Args3) { }

        delegate void VoidDelegate8(int Argument1, int Argument2, int Argument3);
        public static void Void8(int Args1, int Args2, int Args3) { }

        // ===============================================================================

        delegate int ReturnDelegate1();
        public static int Return1() { return 0; }

        delegate int ReturnDelegate2(int Argument1);
        public static int Return2(int Args1) { return 0; }

        delegate string ReturnDelegate3(double Argument1);
        public static string Return3(double Args1) { return String.Empty; }

        delegate double ReturnDelegate4(string Argument1);
        public static double Return4(string Args1) { return 0; }

        delegate bool ReturnDelegate5(int Argument1, double Argument2);
        public static bool Return5(int Args1, double Args2) { return true; }

        delegate char ReturnDelegate6(int Argument1, double Argument2, string Argument3);
        public static char Return6(int Args1, double Args2, string Args3) { return char.MaxValue; }

        delegate long ReturnDelegate7(string Argument1, double Argument2, int Argument3);
        public static long Return7(string Args1, double Args2, int Args3) { return 0; }

        delegate byte ReturnDelegate8(int Argument1, int Argument2, int Argument3);
        public static byte Return8(int Args1, int Args2, int Args3) { return 0; }

        // ===============================================================================

        delegate bool ReturnBool1(int Argument1);
        public static bool BoolMethod1(int Args1) { return true; }

        delegate bool ReturnBool2(string Argument1);
        public static bool BoolMethod2(string Args1) { return true; }

        delegate bool ReturnBool3(double Argument1);
        public static bool BoolMethod3(double Args1) { return true; }

        delegate bool ReturnBool4(int Argument1);
        public static bool BoolMethod4(byte Args1) { return true; }




        static void Main(string[] args)
        {
            VoidDelegate1 var1 = Void1;


        }
    }
}
