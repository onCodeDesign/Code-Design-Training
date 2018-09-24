using System;

namespace LessonsSamples.Lesson6.CoreContainerLifetime
{
    public interface IService
    {
        void ExecuteOperations(string execution);
    }

    public class Service : Operation, IService
    {
        public Service(
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationSingletonInstance instanceOperation)
        {
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
            SingletonInstanceOperation = instanceOperation;
        }

        public IOperationTransient TransientOperation { get; }
        public IOperationScoped ScopedOperation { get; }
        public IOperationSingleton SingletonOperation { get; }
        public IOperationSingletonInstance SingletonInstanceOperation { get; }
        public void ExecuteOperations(string execution)
        {
            Console.WriteLine(execution);
            Console.WriteLine($"Service ID: {this.OperationId}");
            Console.WriteLine($"\tTransient: {TransientOperation.OperationId}");
            Console.WriteLine($"\tScoped: {ScopedOperation.OperationId}");
            Console.WriteLine($"\tSingleton: {SingletonOperation.OperationId}");
            Console.WriteLine($"\tSingletonInstance: {SingletonInstanceOperation.OperationId}");
            Console.WriteLine();
        }
    }
}