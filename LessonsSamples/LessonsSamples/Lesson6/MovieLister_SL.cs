using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;

namespace LessonsSamples.Lesson6.SL
{
    class MovieLister
    {
        private readonly IServiceLocator serviceLocator;

        public MovieLister()
        {
            serviceLocator = ServiceLocator.Current;
        }

        public MovieLister(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public Movie[] GetMoviesDirectedBy(string director)
        {
            IMovieProvider movieProvider = serviceLocator.GetInstance<IMovieProvider>();

            IEnumerable<Movie> allMovies = movieProvider.GetAll();
            List<Movie> resultList = new List<Movie>();
            foreach (var movie in allMovies)
            {
                if (IsDirectedBy(movie, director))
                    resultList.Add(movie);
            }

            return resultList.ToArray();
        }

        private bool IsDirectedBy(Movie movie, string director)
        {
            throw new NotImplementedException();
        }
    }
}