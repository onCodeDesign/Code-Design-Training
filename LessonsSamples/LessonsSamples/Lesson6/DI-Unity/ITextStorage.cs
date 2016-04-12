namespace LessonsSamples.Lesson6.DI_Unity
{
	interface ITextStorage
	{
		void Write(string text);
		void WriteLine(string line);
		string ReadAll();
		string ReadLine(int lineNumber);

		void Clear();
	}
}