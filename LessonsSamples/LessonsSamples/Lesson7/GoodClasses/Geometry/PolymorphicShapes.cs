using System;
using ClassLibrary1;

namespace LessonsSamples.Lesson7.GoodClasses.Polimorphic
{
    interface IShape
    {
        double GetArea();
    }

    class Square : IShape
    {
        private Point topLeft;
        private double side;

        public double GetArea()
        {
            return side * side;
        }
    }

    class Rectangle : IShape
    {
        private Point topLeft;
        private double height;
        private double width;

        public double GetArea()
        {
            return height*width;
        }
    }

    class Circle : IShape
    {
        private Point center;
        private double radius;

        public double GetArea()
        {
            return Math.PI*radius*radius;
        }
    }
}