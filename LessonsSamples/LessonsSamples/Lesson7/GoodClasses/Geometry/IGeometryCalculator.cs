
using LessonsSamples.Lesson7.GoodClasses.Procedural;

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

        public double GetPerimeter(object shape)
        {
            IGeometryCalculator calculator = factory.GetCalculator(shape.GetType());
            return calculator.GetPerimeter(shape);
        }
    }

    interface IGeometryCalculator
    {
        double GetArea(object shape);
        double GetPerimeter(object shape);
    }

    interface IGeometryCalculator<T> : IGeometryCalculator
    {
        double GetArea(T shape);
        double GetPerimeter(T shape);
    }

    abstract class GeometryCalculator<T> : IGeometryCalculator<T>
    {
        public abstract double GetArea(T shape);
        public abstract double GetPerimeter(T shape);

        public double GetArea(object shape)
        {
            return GetArea((T) shape);
        }

        public double GetPerimeter(object shape)
        {
            return GetPerimeter((T) shape);
        }
    }

    
}