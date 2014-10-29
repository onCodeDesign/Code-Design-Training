using System;

namespace Decorator
{
    public interface IWindow
    {
        void Draw();
        string GetDescription();
    }

    public class Window : IWindow
    {
        public void Draw()
        {
            Console.Write("Drawing window");
        }

        public string GetDescription()
        {
            return "Decorator pattern demo";
        }
    }

    public abstract class WindowDecorator : IWindow
    {
        private readonly IWindow decorated;

        protected WindowDecorator(IWindow decorated)
        {
            this.decorated = decorated;
        }

        public virtual void Draw()
        {
            decorated.Draw();
        }

        public string GetDescription()
        {
            return decorated.GetDescription();
        }
    }

    internal class HorizontalScrollBarWindow : WindowDecorator
    {
        public HorizontalScrollBarWindow(IWindow decorated)
            : base(decorated)
        {
        }

        public override void Draw()
        {
            base.Draw();
            DrawHorizontalScrollBar();
        }

        private void DrawHorizontalScrollBar()
        {
            Console.Write(" with horizontal scroll bar");
        }
    }

    internal class VerticalScrollBarWindow : WindowDecorator
    {
        public VerticalScrollBarWindow(IWindow decorated)
            : base(decorated)
        {
        }

        public override void Draw()
        {
            base.Draw();
            DrawVerticalScrollBar();
        }

        private void DrawVerticalScrollBar()
        {
            Console.Write(" with vertical scroll bar");
        }
    }

    
}