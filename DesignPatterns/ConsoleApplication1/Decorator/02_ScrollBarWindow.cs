namespace Decorator
{
    class ScrollBarWindow : DecoratorForWindow
    {
        private readonly IWindow scrollBarWindow;

        public ScrollBarWindow(IWindow decorated) 
            : base(decorated)
        {
            var horizontalScrollBarWindow = new HorizontalScrollBarWindow(decorated);
            scrollBarWindow = new VerticalScrollBarWindow(horizontalScrollBarWindow);
        }

        public override void Draw()
        {
            base.Draw();
            scrollBarWindow.Draw();
        }
    }
}