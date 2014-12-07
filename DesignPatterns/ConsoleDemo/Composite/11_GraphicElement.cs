using System.Collections.Generic;

namespace ConsoleDemo.Composite.Safe
{
    public interface IGraphicElement
    {
        void Draw(int leftMargin);
        string Name { get; set; }

        int Order { get; set; }

        IGraphicElement Parent { get; set; }
    }

    public interface IGraphicElementContainer : IGraphicElement
    {
        void Add(IGraphicElement childElement);
        void Remove(IGraphicElement element);
        IEnumerable<IGraphicElement> GetChildElements();
    }
}