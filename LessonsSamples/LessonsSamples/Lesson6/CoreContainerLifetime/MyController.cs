namespace LessonsSamples.Lesson6.CoreContainerLifetime
{
    public class MyController
    {
        private readonly IService service1;
        private readonly IService service2;

        public MyController(IService service1, IService service2)
        {
            this.service1 = service1;
            this.service2 = service2;
        }

        public void ExecuteRequest()
        {
            service1.ExecuteOperations("Service 1 operations");
            service2.ExecuteOperations("Service 2 operations");
        }
    }
}