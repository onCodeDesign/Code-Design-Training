using System.Collections.Generic;

namespace Composite.Graphics2
{
    public interface IGraphicElement
    {
        void Draw(int leftMargin);
        string Name { get; set; }

        int Order { get; set; }

        IGraphicElement Parent { get; set; }
    }

    interface IGraphicElementContainer : IGraphicElement
    {
        void Add(IGraphicElement childElement);
        void Remove(IGraphicElement element);
        IEnumerable<IGraphicElement> GetChildElements();
    }
}