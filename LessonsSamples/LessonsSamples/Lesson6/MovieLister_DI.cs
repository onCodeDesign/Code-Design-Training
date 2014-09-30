using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;

namespace LessonsSamples.Lesson6.DependencyInjection
{
    class MovieLister : IMovieLister
    {
        public MovieLister(IMovieProvider movieProvider)
            : this(movieProvider, new EmptyFilter())
        {
            this.MovieProvider = movieProvider;
        }

        public void Initialize(IMovieProvider provider, ICountryFilter filter)
        {
            this.movieProvider = provider;
            this.countryFilter = filter;
        }


        public MovieLister(IMovieProvider movieProvider, ICountryFilter countryFilter)
        {
            this.MovieProvider = movieProvider;
            this.CountryFilter = countryFilter;
        }

        private IMovieProvider movieProvider;

        public IMovieProvider MovieProvider
        {
            get { return movieProvider; }
            set { movieProvider = value; }
        }

        private ICountryFilter countryFilter;

        public ICountryFilter CountryFilter
        {
            get { return countryFilter; }
            set { countryFilter = value; }
        }

        public MovieLister(RatingSrvc rating, RelatingSrvc relating)
        {
            throw new NotImplementedException();
        }

        public Movie[] GetMoviesDirectedBy(string director)
        {
            IEnumerable<Movie> allMovies = MovieProvider.GetAll();
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