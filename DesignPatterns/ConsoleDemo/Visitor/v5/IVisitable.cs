namespace ConsoleDemo.Visitor.v5
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}