using System;
using ConsoleDemo.AbstractFactory;
using ConsoleDemo.ChainOfResponsibility;
using ConsoleDemo.Decorator;
using ConsoleDemo.Strategy;
using ConsoleDemo.Visitor.v3;

namespace ConsoleDemo
{
    public static class Program
    {
        public static void Main()
        {
            //AnimalWorldDemo.Run();
            WidgetsDemo.Run();

            //DecoratorClient.Run();

            //Composite.Transparency.CompositeClient.Demo();
            //Composite.Safety.CompositeClient.Demo();

            //StrategyClient.RobotsDemo();

            //ChainOfResponsibilityClient.PurchaseOrderApproverDemo();


			//VisitorDemo3.Run();


            // Wait for user input
            Console.ReadKey();
        }
    }
}