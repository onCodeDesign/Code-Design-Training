using System;

namespace AbstractFactory
{
    class MacScrollBar : IScrollBar
    {
        public void ScrollUp(int points)
        {
            Console.WriteLine("Mac scrolling up");
        }

        public void ScrollDown(int points)
        {
            Console.WriteLine("Mac scrolling down");
        }
    }

    class WinScrollBar : IScrollBar
    {
        public void ScrollUp(int points)
        {
            Console.WriteLine("Win scrolling up");
        }

        public void ScrollDown(int points)
        {
            Console.WriteLine("Win scrolling down");
        }
    }
}