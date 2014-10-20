using System;
using ClassLibrary1;

namespace LessonsSamples.Lesson5
{
    public class Rectangle
    {
        private Point topLeft;
        private double width;
        private double height;

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }


        public decimal Area()
        {
            throw new NotImplementedException();
        }
    }

    class Square2 : Rectangle
    {
        public new double Width
        {
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public new double Height
        {
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }

    class MyExample
    {
        private void g(Rectangle r)
        {
            r.Width = 5;
            r.Height = 4;
            if (r.Area() != 20)
                throw new Exception("Bad area!");
        }


        private void Draw(Rectangle r)
        {
            Screen screen = new Screen(20, 10);
            r.Width = NormalizeWidthTo(screen.Size, r);
            r.Height = NormalizehHeightTo(screen.Size, r);
            screen.Draw(r);
        }

        private double NormalizehHeightTo(int i, Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        private double NormalizeWidthTo(int i, Rectangle rectangle)
        {
            throw new NotImplementedException();
        }
    }

    class Screen
    {
        public Screen(int height, int width)
        {
            throw new NotImplementedException();
        }

        public int Size { get; set; }

        public void Draw(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }
    }
}