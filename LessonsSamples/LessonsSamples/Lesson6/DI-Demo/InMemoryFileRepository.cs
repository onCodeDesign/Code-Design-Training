using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LessonsSamples.Lesson6
{
    class InMemoryFileRepository : IEntityRepository
    {
        private readonly List<Movie> movies = new List<Movie>();

        public IEnumerable<Movie> GetAll()
        {
            return new ReadOnlyCollection<Movie>(movies);
        }

        public void Add(Movie movie)
        {
            movies.Add(movie);
        }
    }
}