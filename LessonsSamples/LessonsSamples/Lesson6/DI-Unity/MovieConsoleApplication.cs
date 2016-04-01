using System;

namespace LessonsSamples.Lesson6.DI_Unity
{
	public class MovieConsoleApplication
	{
		string session = Guid.NewGuid().ToString();
		private readonly IMovieConsoleCreator movieCreator;
		private readonly IMovieTransformer movieTransformer;

		public MovieConsoleApplication(IMovieConsoleCreator movieCreator, IMovieTransformer movieTransformer)
		{
			this.movieCreator = movieCreator;
			this.movieTransformer = movieTransformer;
		}

		public void Run()
		{
			Menu();

			ConsoleKeyInfo c;
			do
			{
				c = Console.ReadKey();

				if (c.KeyChar == '1')
					movieCreator.Open();
				if (c.KeyChar == '2')
					movieTransformer.Run();
				
				Menu();

			} while (c.KeyChar != '0' && c.Key != ConsoleKey.Escape);

		}

		private static void Menu()
		{
			Console.WriteLine(); Console.WriteLine();

			Console.WriteLine("1. Create movies");
			Console.WriteLine("2. Translate movies");
			Console.WriteLine("3. Query movies");
			Console.WriteLine();
			Console.WriteLine("0. Quit");
		}
	}
}