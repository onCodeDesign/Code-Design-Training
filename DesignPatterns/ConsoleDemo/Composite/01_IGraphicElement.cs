using System.Collections.Generic;

namespace ConsoleDemo.Composite.Transparency
{
    public interface IGraphicElement
    {
        void Draw(int leftMargin);
        string Name { get; set; }

        int Order { get; set; }
        IGraphicElement Parent { get; set; }

        void Add(IGraphicElement childElement);
        void Remove(IGraphicElement element);
        IEnumerable<IGraphicElement> GetChildElements();
    }
}