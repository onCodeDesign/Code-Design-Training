using System;
using LessonsSamples.Lesson3.DataModel;

namespace LessonsSamples.Lesson6
{
    class MovieListerFactory
    {
        public static IMovieLister CreateInstance()
        {
            Repository rep = new Repository();

            RatingSrvc rating = new RatingSrvc(rep);
            RelatingSrvc relating = new RelatingSrvc(rep);

            return new MovieLister(rating, relating);
        }

        public static IMovieLister CreateInstance_()
        {
            Repository rep1 = new Repository();
            RatingSrvc rating = new RatingSrvc(rep1);

            Repository rep2 = new Repository();
            RelatingSrvc relating = new RelatingSrvc(rep2);

            return new MovieLister(rating, relating);
        }
    }

    class RelatingSrvc
    {
        public RelatingSrvc(Repository repository)
        {
            throw new NotImplementedException();
        }
    }

    class RatingSrvc
    {
        public RatingSrvc(Repository repository)
        {
            throw new NotImplementedException();
        }
    }

    interface IMovieLister
    {
    }
}