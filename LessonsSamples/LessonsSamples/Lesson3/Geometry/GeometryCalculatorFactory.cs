using System;
using System.Collections.Generic;
using ProceduralShapes;

namespace LessonsSamples.Lesson3.Geometry
{
    internal interface IGeometryCalculatorFactory
    {
        IGeometryCalculator GetCalculator(Type shape);
    }

    class GeometryCalculatorFactory : IGeometryCalculatorFactory
    {
        private readonly Dictionary<Type, Func<IGeometryCalculator>> constructors = new Dictionary<Type, Func<IGeometryCalculator>>
        {
            {typeof (Square), () => new SquareGeometry()},
            {typeof (Rectangle), () => new RectangleGeometry()},
            {typeof (Circle), () => new CircleGeometry()},
            {typeof (Triangle), () => new TriangleGeometry()},
        };


        public IGeometryCalculator GetCalculator(Type shape)
        {
            var constructor = constructors[shape];
            return constructor();
        }
    }

    internal class TriangleGeometry : GeometryCalculator<Triangle>
    {
        public override double GetArea(Triangle shape)
        {
            throw new NotImplementedException();
        }
    }
}