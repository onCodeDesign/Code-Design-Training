using System;

namespace LessonsSamples.Lesson5.ISP.Door.Delegation
{
    public class TimedDoor : IDoor
    {
        private readonly Timer timer;
        private readonly DoorTimerAdapter timerClientAdapter;

        private bool isOpened;
        private Guid timerRegistrationId = Guid.Empty;

        public TimedDoor(Timer timer)
        {
            this.timer = timer;

            timerClientAdapter = new DoorTimerAdapter(this);
        }

        public void Open()
        {
            // code that opens the door
            isOpened = true;

            timerRegistrationId = Guid.NewGuid();
            timer.Register(5, timerClientAdapter, timerRegistrationId);
        }

        public void Close()
        {
            //code that closes the door
            isOpened = false;

            timerRegistrationId = Guid.Empty;
        }

        public bool IsOpened()
        {
            return isOpened;
        }

        public void DoorTimeOut(Guid registrationId)
        {
            if (timerRegistrationId == registrationId)
            {
                // ringing
                Console.WriteLine("ring, riiing, riiiiing!!!");
                Console.WriteLine();

                registrationId = Guid.Empty;
            }
        }
    }
}