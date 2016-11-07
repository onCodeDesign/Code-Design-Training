namespace ConsoleDemo.Visitor.v5
{
public interface IVisitor
{
    void Visit<TElement>(TElement element);
}

public interface IVisitor<TElement>
{
    void Visit(TElement element);
}

    
}