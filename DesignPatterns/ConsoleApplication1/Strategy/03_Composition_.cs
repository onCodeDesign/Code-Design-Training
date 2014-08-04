namespace ConsoleApplication1.Strategy
{
    public class Composition_
    {
        private BreakingStrategy breakingStrategy;

        public void Repair(Configuration configuration, int count, int breaks)
        {
            
            switch (breakingStrategy)
            {
                case BreakingStrategy.SimpleStrategy:
                    ComposeWithSimpleCompositor();
                    break;
                case BreakingStrategy.TeXStrategy:
                    ComposeWithTeXCompositor();
                    break;
                    // ... 
            }
            // merge results with existing composition, if necessary     
        }

        private void ComposeWithSimpleCompositor()
        {
            // ....
        }

        private void ComposeWithTeXCompositor()
        {
            // .....
        }
    }
}