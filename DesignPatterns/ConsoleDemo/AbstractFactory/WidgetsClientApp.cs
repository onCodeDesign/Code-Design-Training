namespace ConsoleDemo.AbstractFactory
{
	public class WidgetsClientApp
	{
		private readonly IWidgetFactory factory;

		public WidgetsClientApp(IWidgetFactory factory)
		{
			this.factory = factory;
		}

		public void Run()
		{
			IWindow window = factory.CreateWidget<IWindow>();
			IScrollBar scrollBar = factory.CreateWidget<IScrollBar>();

			window.SetScrollbars(scrollBar, scrollBar);
			window.Open();
			window.VerticalScrollBar.ScrollDown(10);

			window.Close();
		}
	}
}