using System;

namespace ConsoleDemo.Composite.Safe
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

        public IGraphicElement Parent { get; set; }
    }

    public abstract class PrimitiveGraphic : IGraphicElement
    {
        public abstract void Draw(int leftMargin);

        protected PrimitiveGraphic()
        {
            Name = string.Empty;
        }

        public string Name { get; set; }
        public int Order { get; set; }

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
        private readonly ConsoleColor backColor;

        public GraphicText(string text)
            : this(text, text)
        {
        }

        public GraphicText(string text, ConsoleColor backColor)
            : this(text, text, backColor)
        {
        }

        public GraphicText(string text, string name)
            : this(text, name, ConsoleColor.Black)
        {
        }

        public GraphicText(string text, string name, ConsoleColor backColor)
        {
            Text = text;
            Name = name;
            this.backColor = backColor;
        }

        public string Text { get; set; }

        public override void Draw(int leftMargin)
        {
            string formatedText = string.Format("FormatedText: {0}", Text);

            var color = Console.BackgroundColor;
            Console.BackgroundColor = backColor;

            formatedText.Display(leftMargin);

            Console.BackgroundColor = color;
        }
    }
}