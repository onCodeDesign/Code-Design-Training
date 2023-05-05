using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsSamples.Lesson5
{
	interface IDoor
	{
		void Open();
		void Close();
		bool IsOpened();
	}

	class TimedDoor : IDoor
	{
		private readonly Timer timer = new Timer();
		private Guid lastRegisteredTimerId;

		public void Open()
		{
			this.lastRegisteredTimerId = Guid.NewGuid();
			DoorTimerAdapter doorTimerAdapter = new DoorTimerAdapter(this);
			timer.Register(3, doorTimerAdapter, lastRegisteredTimerId);

			// open
		}

		public void Close()
		{
			throw new NotImplementedException();
		}

		public bool IsOpened()
		{
			throw new NotImplementedException();
		}

		public void Timeout(Guid timerId)
		{
			if (timerId == lastRegisteredTimerId)
			{
				// ring the alarm
			}
		}

		class DoorTimerAdapter : ITimerClient
		{
			private TimedDoor door;

			public DoorTimerAdapter(TimedDoor door)
			{
				this.door = door;
			}

			public void Timeout(Guid timerId)
			{
				door.Timeout(timerId);
			}
		}
	}

	class Timer
	{
		public void Register(int timeout, ITimerClient client, Guid timerId)
		{
			// register timer
			// start clock ->

			client.Timeout(timerId);
		}
	}

	interface ITimerClient
	{
		void Timeout(Guid timerId);
	}
}
