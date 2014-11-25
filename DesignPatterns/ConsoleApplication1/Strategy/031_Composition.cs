using System.Collections.Generic;
using Composite.Graphics1;

namespace ConsoleApplication1.Strategy
{
    public class Client
    {
        public void DoStuff()
        {
            Composition quick = new Composition(new SimpleCompositor());

            Composition slick = new Composition(new TeXCompositor());

            Composition iconic = new Composition(new TabularComposition());
        }
    }


    /// <summary>
    ///     The Composition class maintains a collection of Component instances, which
    ///     represent text and graphical elements in a document.
    ///     A composition arranges component objects into lines using an instance of a
    ///     Compositor subclass, which encapsulates a linebreaking strategy.
    /// 
    ///     Each component has anassociated natural size, stretchability, and shrinkability.
    /// 
    ///     The stretchability defines how much the component can grow beyond its natural size; 
    ///     shrinkability is how much  it can shrink. 
    ///  
    ///     The composition passes these values to a compositor, which uses them to determine 
    ///     the best location for line breaks.
    /// </summary>
    public class Composition
    {
        private List<Component> components;

        private readonly ICompositor compositor;

        public Composition(ICompositor compositor)
        {
            this.compositor = compositor;
        }

        public void Repair(Configuration configuration, int count)
        {
            // prepare the arrays with the desired component sizes 
            // ... 

            // determine where the breaks are: 
            LineBreaks lineBreaks = compositor.Compose(configuration, components);

            // lay out components according to line breaks 
            // ... 
        }
    }


    public class Component
    {
        public int Size { get; set; }
        public int Stretchability { get; set; }
        public int Shrinkability { get; set; }
    }
}