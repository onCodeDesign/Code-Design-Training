using System;
using System.Collections;
using Contracts;
using iQuarc.AppBoot;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    [Service("Generic Menu", typeof(IModule))]
	class GenericMenu : IModule
	{
	    public readonly IConsole console;
	    private readonly IEnumerable<IConsoleCommand> commands;

	    public GenericMenu(IConsole console, IConsoleCommand[] commands)
		{
			this.console = console;
		    this.commands = commands;
		}
	    public void Initialize()
	    {
	        foreach (var cmd in commands.OrderBy(c=>c.TriggerKey))
	        {
	            ShowInMenu(cmd);
	        }

	        ConsoleKey userInput = ReadUserInput();
	        var selectedCmd = commands.FirstOrDefault(c => c.TriggerKey == userInput);
            selectedCmd?.Execute();
	    }

	    private ConsoleKey ReadUserInput()
	    {
	        var r= ConsoleKey.D1;
	        Console.ReadLine();
            return r;
	    }

	    private void ShowInMenu(IConsoleCommand cmd)
	    {
	        console.WriteLine($"{cmd.TriggerKey}. {cmd.Name}");
	    }
	}
}