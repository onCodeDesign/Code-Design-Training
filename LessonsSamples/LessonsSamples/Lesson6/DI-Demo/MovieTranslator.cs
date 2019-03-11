namespace LessonsSamples.Lesson6
{
	class MovieTranslator : IConsoleCommand
	{
		private readonly ITextStorage storage;

		public MovieTranslator(ITextStorage storage)
		{
			this.storage = storage;
		}

		public void Execute()
		{
			string text = storage.ReadAll();

            string transformed = text.ToUpperInvariant(); // being a demo translation = make all uppercase 

            storage.Clear();
			storage.Write(transformed);
		}

	    public char KeyChar => '2';
	    public string MenuEntry => "Translate Movies";
	}
}