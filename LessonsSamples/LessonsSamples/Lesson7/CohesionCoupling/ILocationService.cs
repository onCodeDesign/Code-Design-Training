namespace LessonsSamples.Lesson7.CohesionCoupling
{
    public interface ILocationService
    {
        Coordinates GetCoordinates(string city, string street, string number);
    }

    public class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}