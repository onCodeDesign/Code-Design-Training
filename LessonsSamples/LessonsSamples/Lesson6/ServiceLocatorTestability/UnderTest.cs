using Microsoft.Practices.ServiceLocation;

namespace LessonsSamples.Lesson6.ServiceLocatorTestability
{
    public class UnderTest
    {
        public bool IsOdd()
        {
			var service = ServiceLocator.Current.GetInstance<INumberGeneratorService>();
            int number = service.GenerateNumber();
            return number%2 == 1;
        }
    }
}