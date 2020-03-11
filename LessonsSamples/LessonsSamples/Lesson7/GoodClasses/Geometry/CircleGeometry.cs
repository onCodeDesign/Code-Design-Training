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

        public override double GetPerimeter(Square shape)
        {
            throw new NotImplementedException();
        }
    }

    class RectangleGeometry : GeometryCalculator<Rectangle>
    {
        public override double GetArea(Rectangle r)
        {
            return r.Height*r.Width;
        }

        public override double GetPerimeter(Rectangle shape)
        {
            throw new NotImplementedException();
        }
    }

    class CircleGeometry : GeometryCalculator<Circle>
    {
        public override double GetArea(Circle c)
        {
            return Math.PI * c.Radius * c.Radius;
        }

        public override double GetPerimeter(Circle shape)
        {
            throw new NotImplementedException();
        }
    }

    class TriangleCalculator : GeometryCalculator<Triangle>
    {
        public override double GetArea(Triangle shape)
        {
            throw new System.NotImplementedException();
        }

        public override double GetPerimeter(Triangle shape)
        {
            throw new NotImplementedException();
        }
    }
}