using System;
using ConsoleDemo.AbstractFactory;
using ConsoleDemo.ChainOfResponsibility;
using ConsoleDemo.Decorator;
using ConsoleDemo.Strategy;

namespace ConsoleDemo
{
    public static class Program
    {
        public static void Main()
        {
            ClientApp.RunAbstractFactoryDemo();

            //WidgetsClientApp.Demo();

            //DecoratorClient.Run();

            //Composite.Transparency.CompositeClient.Demo();
            //Composite.Safety.CompositeClient.Demo();

            //StrategyClient.RobotsDemo();

            //ChainOfResponsibilityClient.PurchaseOrderApproverDemo();


            // Wait for user input
            Console.ReadKey();
        }
    }
}