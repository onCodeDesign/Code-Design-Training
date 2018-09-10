using System;
using iQuarc.SystemEx;

namespace LessonsSamples.Lesson6
{
    class AppConsole : IConsole
    {
        public string AskInput(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);

            return Console.ReadLine();
        }

        public void WriteEntity<T>(T salesOrderInfo)
        {
            Console.WriteLine();
            Console.WriteLine($"--------------- {typeof(T).Name} ----------------");
            var properties = ReflectionExtensions.GetEditableSimpleProperties(salesOrderInfo);
            foreach (var propertyInfo in properties)
            {
                Console.Write($"{propertyInfo.Name}: ");
                Console.WriteLine(propertyInfo.GetValue(salesOrderInfo));
            }

            Console.WriteLine("-----------------------------------------------------");
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}