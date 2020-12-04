using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1211
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot robot1 = new Robot("Robot_1", "Test");

            var robots = new List<Robot> { new Robot("Robot_1", "Test") };

            Robot robot2 = new Robot("Robot_1", "Test");

            Console.WriteLine(robots.Contains(robot2));
            Console.WriteLine(robots.Contains(robot1));

        }
    }
}
