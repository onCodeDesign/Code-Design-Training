using System;
using LessonsSamples.Lesson7.GoodClasses.Procedural;

namespace LessonsSamples.Lesson7.GoodClasses.Geometry
{
    class SquareGeometry : GeometryCalculator<Square>
    {
        public override double GetArea(Square s)
        {
            return s.Side * s.Side;
        }
    }

    class RectangleGeometry : GeometryCalculator<Rectangle>
    {
        public override double GetArea(Rectangle r)
        {
            return r.Height*r.Width;
        }
    }

    class CircleGeometry : GeometryCalculator<Circle>
    {
        public override double GetArea(Circle c)
        {
            return Math.PI * c.Radius * c.Radius;
        }
    }
}