using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonsSamples.Lesson6.ServiceLocatorTestability;

namespace LessonsSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            TestRunner.RunTests();

            Console.WriteLine();
            Console.WriteLine("Demo ran. Press enter to close");
            Console.ReadLine();
        }
    }
}
