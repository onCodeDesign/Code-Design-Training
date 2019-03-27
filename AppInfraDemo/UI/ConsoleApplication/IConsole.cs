using System;

namespace ConsoleApplication
{
	internal interface IConsole
	{
		string AskInput(string message);
	    string ReadLine();
	    ConsoleKeyInfo ReadKey();
	    void WriteEntity<T>(T entity);
	    void WriteLine(string line);
	    void Clear();
	}
}