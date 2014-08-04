namespace Decorator
{
    public static class DecoratorClient
    {
        public static void Run()
        {
            var simpleWindow = new Window();
            var verticalScrollWindow = new VerticalScrollBarWindow(simpleWindow);
            var scrollWindow = new HorizontalScrollBarWindow(verticalScrollWindow);

            scrollWindow.Draw();
        }
    }
}