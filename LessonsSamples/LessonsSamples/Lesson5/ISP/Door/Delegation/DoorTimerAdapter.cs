using System;

namespace LessonsSamples.Lesson5.ISP.Door.Delegation
{
    public class DoorTimerAdapter : ITimerClient
    {
        private readonly TimedDoor adaptee;

        public DoorTimerAdapter(TimedDoor adaptee)
        {
            this.adaptee = adaptee;
        }

        public void TimeOut(Guid registrationId)
        {
            adaptee.DoorTimeOut(registrationId);
        }
    }
}