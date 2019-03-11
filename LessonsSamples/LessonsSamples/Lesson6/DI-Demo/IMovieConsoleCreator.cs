using System;
using System.Collections.Generic;

namespace LessonsSamples.Lesson6
{
    public interface IMovieConsoleCreator
	{
		void Open();

	}

	class MovieConsoleCreator : IConsoleCommand
	{
	    private readonly IEntityReader entityReader;
	    private readonly IConsole console;

	    public MovieConsoleCreator(IEntityReader entityReader, IConsole console)
		{
		    this.entityReader = entityReader;
		    this.console = console;
		}

		public void Execute()
		{
			Console.WriteLine("Insert Movies one by one.");
			Console.WriteLine("Press ESC when you are done.");
            Console.WriteLine();

		    IEntityFieldsReader<Movie> movieReader = entityReader.BeginEntityRead<Movie>();
		    IEnumerable<string> movieFields = movieReader.GetFields();
		    foreach (var field in movieFields)
		    {
		       string fieldValue = console.AskInput($"Enter value for: {field}"); 
                movieReader.SetFieldValue(field, fieldValue);
		    }

		    Movie movie = movieReader.GetEntity();

            console.WriteLine("We have read the following entity");
            console.WriteEntity(movie);

			Console.WriteLine();
			Console.WriteLine("Thank you!. Your movies were created");
		}



	    public char KeyChar => '1';
	    public string MenuEntry => "Create Movies";
	}
}