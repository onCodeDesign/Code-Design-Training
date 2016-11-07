namespace ConsoleDemo.Visitor.v6
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}