using System.Collections.Generic;

namespace ConsoleDemo.Strategy
{
    public interface ICompositor
    {
        LineBreaks Compose(Configuration configuration, IEnumerable<Component> components);
    }

    class SimpleCompositor : ICompositor
    {
        public LineBreaks Compose(Configuration configuration, IEnumerable<Component> components)
        {
            throw new System.NotImplementedException();
        }
    }

    class TeXCompositor : ICompositor
    {
        public LineBreaks Compose(Configuration configuration, IEnumerable<Component> components)
        {
            throw new System.NotImplementedException();
        }
    }

    class TabularComposition : ICompositor
    {
        public LineBreaks Compose(Configuration configuration, IEnumerable<Component> components)
        {
            throw new System.NotImplementedException();
        }
    }
}