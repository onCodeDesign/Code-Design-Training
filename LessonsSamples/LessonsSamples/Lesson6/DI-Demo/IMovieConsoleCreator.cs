using System;
using System.Collections.Generic;

namespace LessonsSamples.Lesson6
{
    class MovieConsoleCreator : ICommand
    {
        private readonly IConsole console;
        private readonly IEntityReader entityReader;
        private readonly IEntityRepository repository;

        public MovieConsoleCreator(IConsole console, IEntityReader entityReader, IEntityRepository repository)
        {
            this.console = console;
            this.entityReader = entityReader;
            this.repository = repository;
        }

        public void Execute()
        {
            Console.WriteLine("Insert Movies");
            Console.WriteLine();

            string readMore;
            do
            {
                console.WriteLine("Insert movie properties");

                IEntityFieldsReader<Movie> fieldsReader = entityReader.BeginEntityRead<Movie>();
                IEnumerable<string> fields = fieldsReader.GetFields();
                foreach (var field in fields)
                {
                    string value = console.AskInput($"Please enter values for: {field}");
                    fieldsReader.SetFieldValue(field, value);
                }

                Movie movie = fieldsReader.GetEntity();

                repository.Add(movie);

                readMore = console.AskInput("Do you want to read more movies? [y/n]");
            } while (readMore == "y");

            Console.WriteLine();
            Console.WriteLine("Thank you!. Your movies were created");
        }

        public char KeyChar => '1';
        public string MenuEntry => "Create movies";
    }
}