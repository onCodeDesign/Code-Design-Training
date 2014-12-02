using System.Collections.Generic;

namespace ConsoleDemo.Composite.Graphics1
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