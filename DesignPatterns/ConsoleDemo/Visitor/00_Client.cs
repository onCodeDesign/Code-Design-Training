using System.Collections.Generic;

namespace ConsoleDemo.Visitor
{
	public class Client0
	{
		readonly List<object> items = new List<object>();

		// The client class has a structure (a list in this case) of items or requests.
		// The client knows how to iterate thorugh the structure
		// The client would need to do different operations on the items from the structure when iterating it
	}
}