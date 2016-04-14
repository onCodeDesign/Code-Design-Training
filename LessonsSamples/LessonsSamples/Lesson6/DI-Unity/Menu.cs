using System;
using System.Collections.Generic;
using System.Linq;
using iQuarc.SystemEx.Priority;
using Microsoft.Practices.ServiceLocation;

namespace LessonsSamples.Lesson6.DI_Unity
{
	class Menu : IMenu
	{
		private readonly IEnumerable<IConsoleCommand> comands;

		public Menu()
		{
			this.comands = ServiceLocator.Current.GetAllInstances<IConsoleCommand>()
				.OrderBy(c=>c.MenuEntry);
		}

		public void Show()
		{
			foreach (var consoleCommand in comands)
			{
				Console.WriteLine($"{consoleCommand.MenuEntry}. {consoleCommand.MenuName}");
			}
		}

	}
}