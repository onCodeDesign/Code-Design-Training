using System.Collections.Generic;

namespace LessonsSamples.Lesson6
{
    interface IMovieProvider
    {
        IEnumerable<Movie> GetAll();
    }

    class EmptyFilter : ICountryFilter
    {
    }

    interface ICountryFilter
    {
    }

    interface ITitleMatcher
    {
    }

    class Movie
    {
        public string Title { get; set; }
        public int Rating { get; set; }
    }
}