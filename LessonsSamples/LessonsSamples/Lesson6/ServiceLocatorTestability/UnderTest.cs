using Microsoft.Practices.ServiceLocation;

namespace LessonsSamples.Lesson6.ServiceLocatorTestability
{
    public static class UnderTest
    {
        public static int Boo()
        {
            IService service = ServiceLocator.Current.GetInstance<IService>();
            return service.Foo();
        }
    }
}