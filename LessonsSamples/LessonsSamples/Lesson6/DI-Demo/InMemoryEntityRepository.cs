using System.Collections.Generic;

namespace LessonsSamples.Lesson6
{
    class InMemoryEntityRepository : IEntityRepository
    {
        private readonly List<Movie> movies = new List<Movie>();

        public void Add(Movie movie)
        {
            movies.Add(movie);
        }

        public IEnumerable<Movie> GetAll() => movies;
    }
}