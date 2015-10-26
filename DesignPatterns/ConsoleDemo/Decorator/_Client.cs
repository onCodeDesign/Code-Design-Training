using System;

namespace ConsoleDemo.Decorator
{
    public static class DecoratorClient
    {
        public static void Run()
        {
            var simpleWindow = new Window();
            var verticalScrollWindow = new VerticalScrollBarWindow(simpleWindow);
            var scrollWindow = new HorizontalScrollBarWindow(verticalScrollWindow);

            scrollWindow.Draw();


			Console.WriteLine();
			Console.WriteLine();
			ScrollBarWindow scrollBarWindow = new ScrollBarWindow(simpleWindow);
			scrollBarWindow.Draw();
		}
    }
}