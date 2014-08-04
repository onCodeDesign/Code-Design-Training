using System;

namespace LessonsSamples.Lesson5
{
    class Square : Shape
    {
        public void Draw()
        {
            throw new NotImplementedException();
        }
    }

    class Circle : Shape
    {
        public void Draw()
        {
            throw new NotImplementedException();
        }
    }

    public interface Shape
    {
        void Draw();
    }

    public class MyClass
    {
        public void DrawAllShapes(Shape[] shapes)

        {
            int i;
            for (i = 0; i < shapes.Length; i++)
            {
                shapes[i].Draw();
            }
        }

        private void DrawCircle(Circle circle)
        {
        }

        private void DrawSquare(Square square)
        {
            throw new NotImplementedException();
        }
    }
}