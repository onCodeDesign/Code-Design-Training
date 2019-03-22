using System.Collections.Generic;

namespace LessonsSamples.Lesson6
{
    interface IEntityRepository
    {
        IEnumerable<Movie> GetAll();
        void Add(Movie movie);
    }
}