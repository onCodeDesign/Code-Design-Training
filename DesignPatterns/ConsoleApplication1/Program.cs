using System;
using AbstractFactory;
using Composite.Graphics1;
using ConsoleApplication1.ChainOfResponsibility;
using ConsoleApplication1.Strategy;
using Decorator;

public static class Program
{
    public static void Main()
    {
        //AbstractFactory.ClientApp.RunAbstractFactoryDemo();

        //WidgetsClientApp.Demo();
        
        //DecoratorClient.Run();

        //CompositeClient.Demo();

        StrategyClient.RobotsDemo();

        //ChainOfResponsibilityClient.PurchaseOrderApproverDemo();



        // Wait for user input
        Console.ReadKey();
    }
}