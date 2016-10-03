using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IConsoleCommand
    {
        string Name { get; }
        ConsoleKey TriggerKey { get; }
        void Execute();
    }
}
