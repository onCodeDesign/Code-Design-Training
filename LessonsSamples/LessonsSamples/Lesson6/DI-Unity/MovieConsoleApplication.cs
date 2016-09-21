using System;

namespace LessonsSamples.Lesson6.DI_Unity
{
	public class MovieConsoleApplication
	{
		private readonly IMovieConsoleCreator movieCreator;
		private readonly IMovieTranslator movieTranslator;



		public MovieConsoleApplication(IMenuCommand[] menuCommands)
		{
			this.movieCreator = movieCreator;
			this.movieTranslator = movieTranslator;
		}

		public void Run()
		{
			WriteMenu();

			ConsoleKeyInfo c;
			do
			{
				c = Console.ReadKey();
                WriteLineSeparator();

                if (c.KeyChar == '1')
                    movieCreator.Open();
			    if (c.KeyChar == '2')
			        movieTranslator.TranslateTitles();

                if (!IsExitKey(c))
                    WriteMenu();

			} while (!IsExitKey(c));

		}

	    private static void WriteMenu()
		{
			WriteLineSeparator();

		    Console.WriteLine("1. Create movies");
			Console.WriteLine("2. Translate movies");
			Console.WriteLine("3. List movies");
			Console.WriteLine("4. Find movie");
			Console.WriteLine();
			Console.WriteLine("0. Quit");

            Console.Write("Your command: ");
		}

	    private static void WriteLineSeparator()
	    {
	        Console.WriteLine();
	        Console.WriteLine("------------------------------");
            Console.WriteLine();
	    }

	    private static bool IsExitKey(ConsoleKeyInfo c)
	    {
	        return c.KeyChar == '0' || 
                   c.Key == ConsoleKey.Escape ||
                   c.KeyChar == 'q' || c.KeyChar == 'Q';
	    }
	}
}