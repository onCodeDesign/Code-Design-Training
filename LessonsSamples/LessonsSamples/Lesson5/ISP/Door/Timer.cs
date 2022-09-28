using System;
using System.Threading.Tasks;

namespace LessonsSamples.Lesson5.ISP.Door
{
    public class Timer
    {
        public void Register(int timeoutInSeconds, ITimerClient client, Guid registrationId)
        {
            Task.Delay(TimeSpan.FromSeconds(timeoutInSeconds))
                .ContinueWith(x => client.TimeOut(registrationId));
        }
    }
}