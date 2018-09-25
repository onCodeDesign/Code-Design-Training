using System;

namespace LessonsSamples.Lesson6
{
    class MovieConsoleCreator : ICommand
	{
	    private readonly IEntityReader entityReader;
	    private readonly IConsole console;
	    private readonly IEntityRepository repository;

	    public MovieConsoleCreator(IEntityReader entityReader, IConsole console, IEntityRepository repository)
	    {
	        this.entityReader = entityReader;
	        this.console = console;
	        this.repository = repository;
	    }

        public void Execute()
		{
		    Console.WriteLine("Follow instructions to insert movies");
		    Console.WriteLine("Press ESC when you are done.");
		    Console.WriteLine();
		    string readMore = string.Empty;
		    do
		    {
		        console.WriteLine("------ Enter data for a new Movie ---------");

		        IEntityFieldsReader<Movie> fieldsReader = entityReader.BeginEntityRead<Movie>();
		        foreach (var field in fieldsReader.GetFields())
		        {
		            var value = console.AskInput($"Enter value for: Movie.{field}: ");
		            fieldsReader.SetFieldValue(field, value);
		        }

		        Movie m = fieldsReader.GetEntity();
		        repository.Add(m);

		        readMore = console.AskInput("Enter another movie? [Y/N]");

		    } while (string.Compare(readMore, "y", StringComparison.InvariantCultureIgnoreCase) == 0);

		    Console.WriteLine();
		    Console.WriteLine("Thank you!. Your movies were created");
        }

	    public char KeyChar => '1';
	    public string MenuEntry => "Create Movies";
	}
}