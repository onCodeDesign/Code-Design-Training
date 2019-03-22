using System;
using ClassLibrary1;

namespace ProceduralShapes
{
    class Square
    {
        public Point TopLeft;
        public double Side;
    }

    class Rectangle
    {
        public Point TopLeft;
        public double Height;
        public double Width;
    }

    class Circle
    {
        public Point Center;
        public double Radius;
    }

    class Triangle
    {

    }

    class Geometry
    {
        public double GetArea(object shape)
        {
            if (shape is Square)
            {
                Square s = (Square) shape;
                return s.Side*s.Side;
            }
            else if (shape is Rectangle)
            {
                Rectangle r = (Rectangle) shape;
                return r.Height*r.Width;
            }
            else if (shape is Circle)
            {
                Circle c = (Circle) shape;
                return Math.PI*c.Radius*c.Radius;
            }
            else
                throw new NotSupportedException();
        }
    }
}