using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LessonsSamples.Lesson5.ISP.Door.Delegation
{
    public class DoorDelegationDemo
    {
        public static void MainFunc()
        {
            Timer timer = new Timer();
            TimedDoor door = new TimedDoor(timer);

            Console.WriteLine("Opening the door");
            door.Open();
            Console.WriteLine();


            WaitAsync(3).GetAwaiter().GetResult();

            Console.WriteLine("Closing the door");
            door.Close();
            Console.WriteLine();

            WaitAsync(3).GetAwaiter().GetResult();

            Console.WriteLine("Opening the door");
            door.Open();
            Console.WriteLine();

            WaitAsync(6).GetAwaiter().GetResult();
        }

        private static async Task WaitAsync(int seconds)
        {
            Console.WriteLine($"Waiting {seconds} seconds");
            for (int i = 0; i < seconds; i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                Console.WriteLine($" - {i+1}");
            }

            Console.WriteLine("");
        }
    }
}
