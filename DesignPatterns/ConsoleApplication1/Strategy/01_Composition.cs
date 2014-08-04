namespace ConsoleApplication1.Strategy
{
    public class Client
    {
        public void DoStuff()
        {
            Composition quick = new Composition(new SimpleCompositor());

            Composition slick = new Composition(new TeXCompositor());

            Composition iconic = new Composition(new ArrayCompositor());
        }
    }


    public class Composition
    {
        private readonly ICompositor compositor;

        public Composition(ICompositor compositor)
        {
            this.compositor = compositor;
        }

        public void Repair(Configuration configuration, int count, int breaks)
        {
            // prepare the arrays with the desired component sizes 
            // ... 

            // determine where the breaks are: 
            int lineWidth = 0;
            int breakCount = compositor.Compose(configuration, count, lineWidth, breaks);

            // lay out components according to breaks 
            // ... 
        
        }
    }


    internal enum BreakingStrategy
    {
        SimpleStrategy,
        TeXStrategy
    }
}