using System.Collections.Generic;
using System.Drawing;

namespace ConsoleDemo.Strategy
{
    public class Client
    {
        public void DoStuff()
        {
            PageView quick = new PageView(new InlineStrategy());

            PageView slick = new PageView(new TightStrategy());

            PageView iconic = new PageView(new CenterStrategy());
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
    public class PageView
    {
        private readonly ITextWrappingStrategy wrappingStrategy;
        
        private IEnumerable<Component> componentsStream;
        private PageRow rows;

        public PageView(ITextWrappingStrategy wrappingStrategy)
        {
            this.wrappingStrategy = wrappingStrategy;
        }

        public void Format()
        {
            // prepare the arrays with the desired component sizes 
            // ... 

            // determine where the breaks are: 
            rows = wrappingStrategy.Format(componentsStream);

            Draw();
        }

        private void Draw()
        {
            // layout rows
        }
    }


    public class Component
    {
        public int Size { get; set; }
        public int Stretchability { get; set; }
        public int Shrinkability { get; set; }
    }

    public class Text : Component
    {
        public string Value { get; set; }
        public Font Font { get; set; }
    }

    public class Picture : Component
    {
        public Image Image { get; set; }
    }

    public class Space : Component
    { }
}