namespace ConsoleDemo.Visitor.v3
{
	public interface IVisitable
	{
		void Accept(IVisitor visitor);
	}
}