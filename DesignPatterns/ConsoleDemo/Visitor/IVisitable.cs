using ConsoleDemo.Visitor.v3;

namespace ConsoleDemo.Visitor
{
	public interface IVisitable
	{
		void Accept(IVisitor visitor);
	}
}