namespace ConsoleDemo.Strategy
{
    public class Client_
    {
        public void DoStuff()
        {
            Composition_ quick = new Composition_(BreakingStrategy.SimpleStrategy);

            Composition_ slick = new Composition_(BreakingStrategy.TeXStrategy);

            Composition_ iconic = new Composition_(BreakingStrategy.TabularStrategy);
        }
    }

    public class Composition_
    {
        private BreakingStrategy breakingStrategy;

        public Composition_(BreakingStrategy breakingStrategy)
        {
            this.breakingStrategy = breakingStrategy;
            throw new System.NotImplementedException();
        }

        public void Repair(Configuration configuration, int count)
        {
            // prepare the arrays with the desired component sizes 
            // ... 

            // determine where the breaks are: 
            LineBreaks breaks;
            switch (breakingStrategy)
            {
                case BreakingStrategy.SimpleStrategy:
                    breaks = ComposeWithSimpleCompositor();
                    break;
                case BreakingStrategy.TeXStrategy:
                    ComposeWithTeXCompositor();
                    break;
                    // ... 
            }
            // merge results with existing composition, if necessary     
        }

        private LineBreaks ComposeWithSimpleCompositor()
        {
            return new LineBreaks();
            // ....
        }

        private LineBreaks ComposeWithTeXCompositor()
        {
            return new LineBreaks();
            // .....
        }
    }

    public class LineBreaks
    {
    }

    public enum BreakingStrategy
    {
        SimpleStrategy,
        TeXStrategy,
        TabularStrategy
    }
}