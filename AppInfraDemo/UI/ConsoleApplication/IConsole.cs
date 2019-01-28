namespace ConsoleApplication
{
	internal interface IConsole
	{
		string AskInput(string message);
		void WriteEntity<T>(T entity);
		void WriteLine(string line);
	}
}