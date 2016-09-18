using System;

namespace LessonsSamples.Lesson6.DI_Unity
{
	class MovieTranslator : IMovieTranslator
	{
		private readonly ITextStorage storage;

		public MovieTranslator(ITextStorage storage)
		{
			this.storage = storage;
		}

		public void TranslateTitles()
		{
			string text = storage.ReadAll();

            string transformed = text.ToUpperInvariant(); // being a demo translation = make all uppercase 

            storage.Clear();
			storage.Write(transformed);
		}
	}
}