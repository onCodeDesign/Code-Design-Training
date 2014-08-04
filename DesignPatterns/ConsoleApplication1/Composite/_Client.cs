namespace Composite.Graphics
{
    public static class CompositeClient
    {
        public static void Demo()
        {
            var drawing = new IGraphicElement[]
            {
                new GraphicText("My drawing title!"),
                new Line("First Line"),
                new Picture
                {
                    new GraphicText("A text over my picture"),
                    new Line("A line over my picture"),
                    new Group
                    {
                        new Picture
                        {
                            new Line("A line over the picture"),
                            new Line("Other line over the picture"),
                        },
                        new GraphicText("A text in the group")
                    }
                },
                new Group
                {
                    new Picture(),
                    new Line("line near the picture")
                }
            };

            drawing.Draw();

            //var rootGroup = new Group(drawing);
            //rootGroup.Draw();
        }
    }
}