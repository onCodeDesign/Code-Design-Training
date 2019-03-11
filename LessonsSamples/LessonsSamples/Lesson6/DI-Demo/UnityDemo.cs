using Unity;
using Unity.Lifetime;

namespace LessonsSamples.Lesson6
{
	static class UnityDemo
	{
		public static void MainFunc()
		{
			UnityContainer container = new UnityContainer();

			container.RegisterType<IConsoleCommand, MovieConsoleCreator>(nameof(MovieConsoleCreator));
			container.RegisterType<IConsoleCommand, MovieTranslator>(nameof(MovieTranslator));

			// Demo the difference between PerResolveLifetimeManager and TransientLifetimeManager
			container.RegisterType<ITextStorage, FileStorage>(new PerResolveLifetimeManager()); 


			var app = container.Resolve<MovieConsoleApplication>();
			app.Run();
		}
	}
}