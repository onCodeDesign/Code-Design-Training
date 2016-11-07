using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v2
{
    public class CommandsManager
    {
        readonly List<ICommand> requests = new List<ICommand>();

        public void ApproveAll()
        {
            foreach (var item in requests)
            {
                item.Approve();
            }
        }

        public void PrettyPrint()
        {
            foreach (var item in requests)
            {
                item.PrettyPrint();
            }
        }
    }
}