using System;

namespace LessonsSamples.Lesson6.DI_Unity
{
	class MovieTransformer : IMovieTransformer
	{
		private readonly ITextStorage storage;

		public MovieTransformer(ITextStorage storage)
		{
			this.storage = storage;
		}

		public void Run()
		{
			string text = storage.ReadAll();
			string transformed = text.ToUpperInvariant();
			storage.Clear();
			storage.Write(transformed);
		}
	}
}