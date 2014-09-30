using System.Collections.Generic;

namespace LessonsSamples.Lesson6.InterfaceInjection
{
    interface IMovieProviderInjector
    {
        void InjectMovieProvider(IMovieProvider provider);
    }

    interface IMovieCountryInjector
    {
        void InjectCountryFilter(ICountryFilter filter);
        void InjectTitleMatcher(ITitleMatcher matcher);
    }

    interface ITitleMatcher
    {
    }

    class MovieLister_ : IMovieProviderInjector, IMovieCountryInjector
    {
        private IMovieProvider movieProvider;
        private ICountryFilter countryFilter;
        private ITitleMatcher titleMatcher;

        public void InjectMovieProvider(IMovieProvider provider)
        {
            this.movieProvider = provider;
        }

        public void InjectCountryFilter(ICountryFilter filter)
        {
            this.countryFilter = filter;
        }

        public void InjectTitleMatcher(ITitleMatcher matcher)
        {
            this.titleMatcher = matcher;
        }
    }

    class SqlMovieProvider : IMovieProvider, IDependencyResolver<IMovieProviderInjector>
    {
        public void Resolve(IMovieProviderInjector injector)
        {
            injector.InjectMovieProvider(this);
        }

      public IEnumerable<Movie> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }

    interface IDependencyResolver<T>
    {
        void Resolve(T injector);
    }
}