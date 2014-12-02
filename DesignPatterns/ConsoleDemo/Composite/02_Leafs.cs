using System;
using System.Collections.Generic;

namespace ConsoleDemo.Composite.Graphics1
{
    public class Line : IGraphicElement
    {
        public Line(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Order { get; set; }

        public void Draw(int leftMargin)
        {
            Name.Display(leftMargin);
        }

        public void Add(IGraphicElement childElement)
        {
            throw new NotSupportedException("You cannot add a child element to a Line");
        }

        public void Remove(IGraphicElement element)
        {
            throw new NotSupportedException("A Line does not have children to remove from");
        }

        public IEnumerable<IGraphicElement> GetChildElements()
        {
            yield break;
        }

        public IGraphicElement Parent { get; set; }
    }


    public abstract class PrimitiveGraphic : IGraphicElement
    {
        public abstract void Draw(int leftMargin);

        public string Name { get; set; }
        public int Order { get; set; }

        public void Add(IGraphicElement childElement)
        {
            throw new NotSupportedException(string.Format("You cannot add a child element to a {0}", GetType().Name));
        }

        public void Remove(IGraphicElement element)
        {
            throw new NotSupportedException(string.Format("A {0} does not have children to remove from", GetType().Name));
        }

        public IEnumerable<IGraphicElement> GetChildElements()
        {
            yield break;
        }

        public IGraphicElement Parent { get; set; }
    }

    public sealed class Rectangle : PrimitiveGraphic
    {
        public override void Draw(int leftMargin)
        {
            Name.Display(leftMargin);
        }
    }

    public sealed class GraphicText : PrimitiveGraphic
    {
        public GraphicText(string text, string name)
        {
            Text = text;
            Name = name;
        }

        public GraphicText(string text)
            : this(text, text)
        {
        }

        public string Text { get; set; }

        public override void Draw(int leftMargin)
        {
            string formatedText = string.Format("FormatedText: '{0}", Text);
            formatedText.Display(leftMargin);
        }
    }
}