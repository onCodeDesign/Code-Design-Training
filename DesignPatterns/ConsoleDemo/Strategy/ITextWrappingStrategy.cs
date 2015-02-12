using System.Collections.Generic;

namespace ConsoleDemo.Strategy
{
    public interface ITextWrappingStrategy
    {
        PageRow Format(IEnumerable<Component> componentsStream);
    }

    class InlineStrategy : ITextWrappingStrategy
    {
        public PageRow Format(IEnumerable<Component> componentsStream)
        {
            throw new System.NotImplementedException();
        }
    }

    class TightStrategy : ITextWrappingStrategy
    {
        public PageRow Format(IEnumerable<Component> componentsStream)
        {
            throw new System.NotImplementedException();
        }
    }

    class CenterStrategy : ITextWrappingStrategy
    {
        public PageRow Format(IEnumerable<Component> componentsStream)
        {
            throw new System.NotImplementedException();
        }
    }
}