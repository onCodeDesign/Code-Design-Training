using System;
using System.Collections.Generic;

namespace ConsoleDemo.AbstractFactory
{
	public class WidgetsDemo
    {
        public static void Run()
        {
            Console.WriteLine("Playing with Windows UI");
            IWidgetFactory winFactory = new WinWidgetFactory();
            var winApp = new WidgetsClientApp(winFactory);
			winApp.Run();

            Console.WriteLine();
            Console.WriteLine("Playing with Mac UI");
            IWidgetFactory macFactory = new MacWidgetFactory();
            var macApp = new WidgetsClientApp(macFactory);
			macApp.Run();
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

	public interface IWidgetFactory
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