using Microsoft.Practices.ServiceLocation;

namespace LessonsSamples.Lesson6.ServiceLocatorTestability
{
    public class UnderTest
    {
        public bool IsOdd()
        {
            IService service = ServiceLocator.Current.GetInstance<IService>();
            int number = service.Foo();
            return number%2 == 1;
        }
    }
}