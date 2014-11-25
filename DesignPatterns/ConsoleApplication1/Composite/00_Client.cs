using System;
using Composite.Graphics2;

namespace Composite.Graphics1
{
    public static class CompositeClient
    {
        public static void Demo()
        {
            Demo1();

            Demo2();
        }

        private static IGraphicElement[] Demo1()
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
            return drawing;
        }

        private static void Demo2()
        {
            Console.WriteLine("Build a drawing ...");
            var line = new Line("A first line");
            
            //var lineInThePicture
            var picture = new Picture();


            Console.WriteLine("Edit the drawing ...");

        }

        private static IGraphicElementContainer BuildDrawing()
        {
            throw new NotImplementedException();
        }
    }
}