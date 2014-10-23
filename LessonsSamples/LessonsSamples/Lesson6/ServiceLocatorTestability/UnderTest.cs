using Microsoft.Practices.ServiceLocation;

namespace LessonsSamples.Lesson6.ServiceLocatorTestability
{
    public class UnderTest
    {
        public int Boo()
        {
            IService service = ServiceLocator.Current.GetInstance<IService>();
            return service.Foo();
        }
    }
}