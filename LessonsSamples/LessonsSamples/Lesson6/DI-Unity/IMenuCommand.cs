using System;
using iQuarc.AppBoot;

namespace LessonsSamples.Lesson6.DI_Unity
{
    public interface IMenuCommand
    {
        void Execute();
    }

    [Service(typeof(IMenuCommand))]
    class AllCommands : IMenuCommand
    {
        private readonly IMenuCommand[] commands;

        public AllCommands(IMenuCommand[] commands)
        {
            this.commands = commands;
        }

        public void Execute()
        {
            foreach (var cmd in commands)
            {
                cmd.Execute();
            }
        }
    }

    [Service("Create Movies Command", typeof(IMenuCommand))]
    class CreateMoviesCommand : IMenuCommand
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}