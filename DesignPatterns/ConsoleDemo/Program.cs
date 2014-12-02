using System;
using ConsoleDemo.Composite.Graphics1;
using ConsoleDemo.Strategy;

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