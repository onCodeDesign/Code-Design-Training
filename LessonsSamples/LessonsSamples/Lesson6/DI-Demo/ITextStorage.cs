namespace LessonsSamples.Lesson6
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