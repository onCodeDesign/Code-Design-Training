using System;
using System.Collections.Generic;

namespace LessonsSamples.Lesson6
{
    internal interface IEntityFieldsReader<T>
    {
        IEnumerable<string> GetFields();
        void SetFieldValue(string name, string value);

        T GetEntity();
    }

    class MovieFieldsReader : IEntityFieldsReader<Movie>
    {
        private static readonly Dictionary<string, Action<Movie, string>> fieldSetters = new Dictionary<string, Action<Movie, string>>
        {
            {nameof(Movie.Title), (movie, value) => movie.Title = value},
            {nameof(Movie.Rating), (movie, value) => { int.TryParse(value, out var rating);
                                                        movie.Rating = rating;
                                                     }
            },
        };

        private readonly Movie movie;

        public MovieFieldsReader()
        {
            movie = new Movie();
        }

        public IEnumerable<string> GetFields() => fieldSetters.Keys;

        public void SetFieldValue(string name, string value)
        {
            var setter = fieldSetters[name];
            setter(movie, value);
        }

        public Movie GetEntity() => movie;
    }
}