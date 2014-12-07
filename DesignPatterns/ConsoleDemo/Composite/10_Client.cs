using System;

namespace ConsoleDemo.Composite.Safe
{
    public static class CompositeClient
    {
        public static void Demo()
        {
            //Demo1();

            Demo2();
        }

        private static void Demo1()
        {
            var drawing = BuildDrawing();
            drawing.Draw();
        }

        private static void Demo2()
        {
            Console.WriteLine("Build a drawing ...");
            var drawing = BuildDrawing();
            drawing.Draw();

            Console.WriteLine("\n----------- Edit the drawing -----------");
            Console.WriteLine("adding a text to all elements which contain 'great' ");

            GraphicText text = new GraphicText("This is a nice graphic", ConsoleColor.DarkBlue);

            foreach (IGraphicElement element in drawing.GetChildElements())
            {
                if (element.Name.Contains("great"))
                {
                    IGraphicElementContainer container = element as IGraphicElementContainer;
                    if (container != null)
                    {
                        container.Add(text);
                    }
                }
            }


            Console.WriteLine("\n-----------The drawing after edit ---------");
            drawing.Draw();
        }

        private static Drawing BuildDrawing()
        {
            var drawing = new Drawing
            {
                new GraphicText("My drawing title!"),
                new Line("First Line"),
                new Picture("great view")
                {
                    new GraphicText("A text over my great picture"),
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

            return drawing;
        }
    }
}