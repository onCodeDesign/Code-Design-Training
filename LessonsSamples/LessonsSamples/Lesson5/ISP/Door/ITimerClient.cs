using System;

namespace LessonsSamples.Lesson5.ISP.Door
{
    public interface ITimerClient
    {
        void TimeOut(Guid registrationId);
    }
}