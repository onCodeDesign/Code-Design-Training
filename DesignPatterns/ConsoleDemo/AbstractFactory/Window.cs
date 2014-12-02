using System;

namespace ConsoleDemo.AbstractFactory
{
    class MacWindow : IWindow
    {
        public void Open()
        {
            Console.WriteLine("Mac Window opened");
        }

        public void Close()
        {
            Console.WriteLine("Mac Window closed");
        }

        public IScrollBar VerticalScrollBar { get; private set; }
        public IScrollBar HorizontalScrollBar { get; private set; }
        public void SetScrollbars(IScrollBar vertical, IScrollBar horizontal)
        {
            VerticalScrollBar = vertical;
            HorizontalScrollBar = horizontal;
        }
    }

    class WinWindow : IWindow
    {
        public void Open()
        {
            Console.WriteLine("Win Window opened");
        }

        public void Close()
        {
            Console.WriteLine("Win Window closed");
        }

        public IScrollBar VerticalScrollBar { get; private set; }
        public IScrollBar HorizontalScrollBar { get; private set; }
        public void SetScrollbars(IScrollBar vertical, IScrollBar horizontal)
        {
            VerticalScrollBar = vertical;
            HorizontalScrollBar = horizontal;
        }
    }
}