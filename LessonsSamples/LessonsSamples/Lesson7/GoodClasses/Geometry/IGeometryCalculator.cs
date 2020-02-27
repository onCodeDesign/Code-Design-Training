
namespace LessonsSamples.Lesson7.GoodClasses.Geometry
{
    class Geometry : IGeometryCalculator
    {
        private readonly IGeometryCalculatorFactory factory = new GeometryCalculatorFactory();

        public double GetArea(object shape)
        {
            IGeometryCalculator calculator = factory.GetCalculator(shape.GetType());
            return calculator.GetArea(shape);
        }


    }

    interface IGeometryCalculator
    {
        double GetArea(object shape);
    }

    interface IGeometryCalculator<T> : IGeometryCalculator
    {
        double GetArea(T shape);
    }

    abstract class GeometryCalculator<T> : IGeometryCalculator<T>
    {
        public abstract double GetArea(T shape);

        public double GetArea(object shape)
        {
            return GetArea((T) shape);
        }
    }
}