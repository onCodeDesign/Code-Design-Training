using System;
using iQuarc.SystemEx;

namespace ConsoleUi
{
    class ConsoleEx
    {
        public static T AskInput<T>(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);

            string input = Console.ReadLine();
            return ConvertExtensions.ChangeType<T>(input);
        }

        public static void WriteEntity<T>(T entity)
        {
            Console.WriteLine();
            Console.WriteLine($"--------------- {typeof(T).Name} ----------------");
            var properties = ReflectionExtensions.GetEditableSimpleProperties(entity);
            foreach (var propertyInfo in properties)
            {
                Console.Write($"{propertyInfo.Name}: ");
                Console.WriteLine(propertyInfo.GetValue(entity));
            }
        }
    }
}