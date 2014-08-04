using System;
using System.Collections.Generic;

namespace Composite.Graphics
{
    internal static class DisplayExtension
    {
        public static void Display(this string text, int margin)
        {
            Console.WriteLine(new string(' ', margin*2) + text);
        }
    }

    internal static class GraphiEelementExtensions
    {
        public static void Draw(this IGraphicElement graphic)
        {
            graphic.Draw(0);
        }

        public static void Draw(this IGraphicElement[] drawing)
        {
            foreach (var graphicElement in drawing)
            {
                graphicElement.Draw();
            }
        }
    }
}