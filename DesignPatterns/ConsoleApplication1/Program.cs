using System;
using AbstractFactory;
using Composite.Graphics;
using ConsoleApplication1.ChainOfResponsibility;
using ConsoleApplication1.Strategy;
using Decorator;

public static class Program
{
    public static void Main()
    {
        //WidgetsClientApp.Demo();
        
        //DecoratorClient.Run();

        //CompositeClient.Demo();

        StrategyClient.RobotsDemo();

        //ChainOfResponsabilityClient.PurchaseOrderApproverDemo();



        // Wait for user input
        Console.ReadKey();
    }
}