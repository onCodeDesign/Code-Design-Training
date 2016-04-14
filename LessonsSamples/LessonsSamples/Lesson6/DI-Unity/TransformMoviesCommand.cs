using System;
using iQuarc.SystemEx.Priority;

namespace LessonsSamples.Lesson6.DI_Unity
{
	internal class TransformMoviesCommand : IConsoleCommand
	{
		public bool CanExecute(object parameter)
		{
			throw new NotImplementedException();
		}

		public void Execute(object parameter)
		{
			throw new NotImplementedException();
		}

		public event EventHandler CanExecuteChanged;
		public string MenuName => "Transform Movies";
		public char MenuEntry => '1';
	}
}