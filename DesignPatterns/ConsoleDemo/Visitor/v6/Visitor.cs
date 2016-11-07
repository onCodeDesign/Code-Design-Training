namespace ConsoleDemo.Visitor.v6
{
    sealed class Visitor : IVisitor
    {
        private readonly object specificVisitor;

        public Visitor(object specificVisitor)
        {
            this.specificVisitor = specificVisitor;
        }

        public void Visit<TElement>(TElement element)
        {
            IVisitor<TElement> v = specificVisitor as IVisitor<TElement>;
            v?.Visit(element);
        }
    }
}