using System;
using System.Collections.Generic;
using CommonServiceLocator;

namespace LessonsSamples.Lesson6
{
    interface IEntityReader
    {
        IEntityFieldsReader<T> BeginEntityRead<T>();
    }

    class EntityReader : IEntityReader
    {
        private readonly IServiceLocator serviceLocator;

        public EntityReader(IServiceLocator serviceLocator)
        {
            //this.serviceLocator = serviceLocator;
            //ServiceLocator.Current.
        }

        public IEntityFieldsReader<T> BeginEntityRead<T>()
        {
            return ServiceLocator.Current.GetInstance<IEntityFieldsReader<T>>();
        }
    }

    class MovieFieldsReader : IEntityFieldsReader<Movie>
    {
        private static readonly Dictionary<string, Action<Movie, string>> fieldSetters = new Dictionary<string, Action<Movie, string>>
        {
            {nameof(Movie.Title), (movie, value) => movie.Title = value},

            { nameof(Movie.Rating), (movie, value) => {
                int.TryParse(value, out var rating);
                movie.Rating = rating;
            }},
        };

        private readonly Movie movie;

        public MovieFieldsReader()
        {
            this.movie = new Movie();
        }

        public IEnumerable<string> GetFields() => fieldSetters.Keys;

        public void SetFieldValue(string field, string value)
        {
            var setter = fieldSetters[field];
            setter(movie, value);
        }

        public Movie GetEntity() => movie;
    }

}