using System.Collections.Generic;

namespace ConsoleDemo.Strategy
{
    public class Client_
    {
        public void DoStuff()
        {
            PageView_ inline = new PageView_(TextWrapping.Inline);

            PageView_ slick = new PageView_(TextWrapping.Tight);

            PageView_ iconic = new PageView_(TextWrapping.Center);
        }
    }

	/// <summary>
	///     The PageView class maintains a collection of Component instances, which
	///     represent text and graphical elements in a document.
	///     When size changes, it reformates the content by arranging its components into lines 
	///     using a TextWrappingStrategy, which encapsulates a the logic of breaking the compoenent on rows
	///     and wrapping the text around the pictures.
	/// 
	///     Each component has an associated natural size, stretchability, and shrinkability.
	/// 
	///     The stretchability defines how much the component can grow beyond its natural size; 
	///     shrinkability is how much  it can shrink. 
	/// </summary>
	public class PageView_
    {
        private TextWrapping textWrapping;

        private IEnumerable<Component> componentsStream;
        private PageRow rows; 

        public PageView_(TextWrapping textWrapping)
        {
            this.textWrapping = textWrapping;
        }

        public void Format()
        {
            // prepare the arrays with the desired component sizes 
            // ... 

            // rebuild the rows filed
            switch (textWrapping)
            {
                case TextWrapping.Inline:
                    rows = InlineWrapping();
                    break;
                case TextWrapping.Tight:
                    rows = TightWrapping();
                    break;
                case TextWrapping.Center:
                    rows = CenterWrapping();
                    break;
                    // ... 
            }

            Draw();
        }

        public void Draw()
        {
            // layout rows
        }

        private PageRow InlineWrapping()
        {
            return new PageRow();
            // ....
        }

        private PageRow CenterWrapping()
        {
            return new PageRow();
            // ....
        }

        private PageRow TightWrapping()
        {
            return new PageRow();
            // .....
        }
    }

    public class PageRow
    {
        public Component[] Components { get; set; }
    }

    public enum TextWrapping
    {
        Inline,
        Tight,
        Center
    }
}