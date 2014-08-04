using System.Collections.Generic;

namespace Composite.Graphics
{
    public interface IGraphicElement
    {
        void Draw(int leftMargin);
        string Name { get; set; }

        int Order { get; set; }

        void Add(IGraphicElement childElement);
        void Remove(IGraphicElement element);
        IEnumerable<IGraphicElement> GetChildElements();
        IGraphicElement Parent { get; set; }
    }
}