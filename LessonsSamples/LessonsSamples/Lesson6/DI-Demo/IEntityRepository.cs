using System.Collections.Generic;

namespace LessonsSamples.Lesson6
{
    internal interface IEntityRepository
    {
        IEnumerable<Movie> GetAll();
        void Add(Movie movie);
    }
}