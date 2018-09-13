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

    class MovieLister_ : IMovieProviderInjector, IMovieCountryInjector
    {
        private IMovieProvider movieProvider;
        private ICountryFilter countryFilter;
        private ITitleMatcher titleMatcher;

        public void InjectMovieProvider(IMovieProvider provider)
        {
            movieProvider = provider;
        }

        public void InjectCountryFilter(ICountryFilter filter)
        {
            countryFilter = filter;
        }

        public void InjectTitleMatcher(ITitleMatcher matcher)
        {
            titleMatcher = matcher;
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
            yield return new Movie();
            yield return new Movie();
            yield return new Movie();
        }
    }

    //DI Container collects all these and kicks resolve
    interface IDependencyResolver<T>
    {
        void Resolve(T injector);
    }
}