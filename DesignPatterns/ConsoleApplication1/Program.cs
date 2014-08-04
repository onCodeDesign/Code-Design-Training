using System;
using Composite.Graphics;
using ConsoleApplication1.ChainOfResponsibility;
using ConsoleApplication1.Strategy;

public static class Program
{
    public static void Main()
    {
        //DecoratorClient.Run();

        //CompositeClient.Demo();

        //StrategyClient.RobotsDemo();

        ChainOfResponsabilityClient.PurchaseOrderApproverDemo();

        // Wait for user input
        Console.ReadKey();
    }
}