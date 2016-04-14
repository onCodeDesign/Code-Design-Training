using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Input;
using iQuarc.SystemEx.Priority;

namespace LessonsSamples.Lesson6.DI_Unity
{
	interface IConsoleCommand : ICommand
	{
		 string MenuName { get; }

		 char MenuEntry { get; }

	}

	interface ICreateMoviesCommand : IConsoleCommand
	{
	}

	class CreateMoviesCommand : ICreateMoviesCommand
	{
		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			throw new NotImplementedException();
		}

		public event EventHandler CanExecuteChanged;
		public string MenuName => "Create Movies";
		public char MenuEntry => '2';
	}

	public class MovieConsoleApplication
	{
		private readonly IMenu consoleMenu;

		public MovieConsoleApplication(IMenu consoleMenu)
		{
			this.consoleMenu = consoleMenu;
		}

		public void Run()
		{
			consoleMenu.Show();


			//ConsoleKeyInfo c;
			//do
			//{
			//	c = Console.ReadKey();

			//	if (c.KeyChar == '1')
			//		movieCreator.Open();
			//	if (c.KeyChar == '2')
			//		movieTransformer.Run();
				
			//	Menu();

			//} while (c.KeyChar != '0' && c.Key != ConsoleKey.Escape);

		}

		private static void Menu()
		{


			Console.WriteLine(); Console.WriteLine();

			Console.WriteLine("1. Create movies");
			Console.WriteLine("2. Translate movies");
			Console.WriteLine("3. List movies");
			Console.WriteLine("4. Find movie");
			Console.WriteLine("0. Quit");
		}
	}

	public interface IMenu
	{
		void Show();
	}
}