namespace ConsoleDemo.Visitor.v6
{
    public interface IVisitor
    {
        void Visit<TElement>(TElement element);
    }

 public interface IVisitor<TElement>
 {
     void Visit(TElement element);
     IVisitor AsVisitor();
 }
}