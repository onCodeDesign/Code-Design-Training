using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v0
{
    public class CommandsManager
    {
        readonly List<object> items = new List<object>();

        // The client class has a structure (a list in this case) of items (commands).
        // The client knows how to iterate through the structure
        // The client would need to do different operations on the items from the structure when iterating it
    }
}