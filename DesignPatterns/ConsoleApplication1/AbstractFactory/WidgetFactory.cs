using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    public class WidgetsClientApp
    {
        public static void Demo()
        {
            Console.WriteLine("Playing with Windows UI");
            IWidgetFactory winFactory = new WinWidgetFactory();
            PlayWith(winFactory);

            Console.WriteLine();
            Console.WriteLine("Playing with Mac UI");
            IWidgetFactory macFactory = new MacWidgetFactory();
            PlayWith(macFactory);
        }

        private static void PlayWith(IWidgetFactory factory)
        {
            IWindow window = factory.CreateWidget<IWindow>();
            IScrollBar scrollBar = factory.CreateWidget<IScrollBar>();

            window.SetScrollbars(scrollBar, scrollBar);
            window.Open();
            window.VerticalScrollBar.ScrollDown(10);

            window.Close();
        }
    }


    interface IWindow
    {
        void Open();
        void Close();

        IScrollBar VerticalScrollBar { get; }
        IScrollBar HorizontalScrollBar { get; }
        void SetScrollbars(IScrollBar vertical, IScrollBar horizontal);
    }

    interface IScrollBar
    {
        void ScrollUp(int points);
        void ScrollDown(int points);
    }

    interface IWidgetFactory
    {
        T CreateWidget<T>();
    }

    class MacWidgetFactory : IWidgetFactory
    {
        private readonly Dictionary<Type, Func<object>> factories = new Dictionary<Type, Func<object>>
        {
            {typeof (IWindow), () => new MacWindow()},
            {typeof (IScrollBar), () => new MacScrollBar()}
        };

        public T CreateWidget<T>()
        {
            Func<object> factory = factories[typeof (T)];

            T widget = (T) factory();
            return widget;
        }
    }

    class WinWidgetFactory : IWidgetFactory
    {
        private readonly Dictionary<Type, Func<object>> factories = new Dictionary<Type, Func<object>>
        {
            {typeof (IWindow), () => new WinWindow()},
            {typeof (IScrollBar), () => new WinScrollBar()}
        };

        public T CreateWidget<T>()
        {
            Func<object> factory = factories[typeof (T)];

            T widget = (T) factory();
            return widget;
        }
    }
}