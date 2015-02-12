using System.Collections.Generic;

namespace ConsoleDemo.Strategy
{
    public class Client_
    {
        public void DoStuff()
        {
            PageView_ inline = new PageView_(TextWrapping.Inline);

            PageView_ slick = new PageView_(TextWrapping.Tight);

            PageView_ iconic = new PageView_(TextWrapping.Center);
        }
    }

    public class PageView_
    {
        private TextWrapping textWrapping;

        private IEnumerable<Component> componentsStream;
        private PageRow rows; 

        public PageView_(TextWrapping textWrapping)
        {
            this.textWrapping = textWrapping;
        }

        public void Format()
        {
            // prepare the arrays with the desired component sizes 
            // ... 

            // rebuild the rows filed
            switch (textWrapping)
            {
                case TextWrapping.Inline:
                    rows = InlineWrapping();
                    break;
                case TextWrapping.Tight:
                    rows = TightWrapping();
                    break;
                case TextWrapping.Center:
                    rows = CenterWrapping();
                    break;
                    // ... 
            }

            Draw();
        }

        public void Draw()
        {
            // layout rows
        }

        private PageRow InlineWrapping()
        {
            return new PageRow();
            // ....
        }

        private PageRow CenterWrapping()
        {
            return new PageRow();
            // ....
        }

        private PageRow TightWrapping()
        {
            return new PageRow();
            // .....
        }
    }

    public class PageRow
    {
        public Component[] Components { get; set; }
    }

    public enum TextWrapping
    {
        Inline,
        Tight,
        Center
    }
}