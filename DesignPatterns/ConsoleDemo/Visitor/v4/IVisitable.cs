namespace ConsoleDemo.Visitor.v4
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}