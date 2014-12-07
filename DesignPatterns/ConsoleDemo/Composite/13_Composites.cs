using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDemo.Composite.Safe
{
    public class Picture : IGraphicElementContainer, IEnumerable<IGraphicElement>
    {
        private readonly LinkedList<IGraphicElement> children = new LinkedList<IGraphicElement>();

        public Picture()
            : this(string.Empty)
        {
        }

        public Picture(string name)
        {
            Name = name;
        }

        public void Draw(int leftMargin)
        {
            string pci = string.Format("Picture {0} containing:", Name);
            pci.Display(leftMargin);

            foreach (var graphicElement in children) //.OrderBy(e => e.Name))
            {
                graphicElement.Draw(leftMargin + 1);
            }
        }

        public string Name { get; set; }
        public int Order { get; set; }

        public void Add(IGraphicElement childElement)
        {
            children.AddLast(childElement);
            childElement.Parent = this;
        }

        public void Remove(IGraphicElement element)
        {
            children.Remove(element);
            element.Parent = null;
        }

        public IEnumerable<IGraphicElement> GetChildElements()
        {
            return children;
        }

        public IGraphicElement Parent { get; set; }


        #region IEnumerable

        // This is implemented only to allow a array initialization in the client code

        public IEnumerator<IGraphicElement> GetEnumerator()
        {
            return GetChildElements().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

    }

    public abstract class CompositeElement : IGraphicElement, IEnumerable<IGraphicElement>
    {
        private readonly LinkedList<IGraphicElement> children = new LinkedList<IGraphicElement>();
        private int lastOrder;

        protected CompositeElement()
        {
            Name = string.Empty;
        }

        public abstract void Draw(int leftMargin);

        public string Name { get; set; }
        public int Order { get; set; }

        public void Add(IGraphicElement childElement)
        {
            children.AddLast(childElement);

            childElement.Parent = this;
            childElement.Order = lastOrder++;
        }

        public void Remove(IGraphicElement element)
        {
            children.Remove(element);

            element.Parent = null;
            element.Order = 0;
        }

        public IEnumerable<IGraphicElement> GetChildElements()
        {
            return children;
        }

        public IGraphicElement Parent { get; set; }

        #region IEnumerable

        public IEnumerator<IGraphicElement> GetEnumerator()
        {
            return GetChildElements().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }

    class Group : CompositeElement
    {
        public Group()
        {
        }

        public Group(IEnumerable<IGraphicElement> elements)
        {
            foreach (var element in elements)
            {
                Add(element);
            }
        }

        public override void Draw(int leftMargin)
        {
            "Grouping:".Display(leftMargin);

            var children = GetChildElements().OrderByDescending(e => e.Order);
            foreach (var element in children)
            {
                element.Draw(leftMargin + 2);
            }
        }
    }

    class Drawing : CompositeElement
    {
        public Drawing()
        {
        }

        public override void Draw(int leftMargin)
        {
            var children = GetChildElements();
            foreach (var graphicElement in children)
            {
                graphicElement.Draw(leftMargin);
            }
        }
    }
}