namespace Composite.Graphics2
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