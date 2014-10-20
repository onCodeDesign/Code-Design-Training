namespace LessonsSamples.Lesson7.CohesionCoupling
{
    public interface ICrmService
    {
        CustomerInfo GetCustomerInfo(string customerName);
    }

    public class CustomerInfo
    {
    }
}