using System;
using ConsoleDemo.AbstractFactory;
using ConsoleDemo.ChainOfResponsibility;
using ConsoleDemo.Decorator;
using ConsoleDemo.Strategy;
using ConsoleDemo.Visitor.v3;
using ConsoleDemo.Visitor.v5;
using ConsoleDemo.Visitor.v6;

namespace ConsoleDemo
{
    public static class Program
    {
        public static void Main()
        {
            AnimalWorldDemo.Run();
            //WidgetsDemo.Run();

            //DecoratorClient.Run();

            //Composite.Transparency.CompositeClient.Demo();
            //Composite.Safety.CompositeClient.Demo();

            //StrategyClient.RobotsDemo();

            //ChainOfResponsibilityClient.PurchaseOrderApproverDemo();


			//VisitorDemo5.Run();
			//VisitorDemo6.Run();


            // Wait for user input
            Console.ReadLine();
        }
    }
}