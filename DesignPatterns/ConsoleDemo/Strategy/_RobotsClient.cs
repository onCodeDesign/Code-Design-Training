using System;

namespace ConsoleDemo.Strategy
{
    public class StrategyClient
    {
        public static void RobotsDemo()
        {
            Robot bigRobot = new Robot("Big Robot");
            Robot george = new Robot("George v.2.1");
            Robot r2 = new Robot("R2");

            bigRobot.Behaviour = new AgressiveBehaviour();
            george.Behaviour = new DefensiveBehaviour();
            r2.Behaviour = new NormalBehaviour();

            bigRobot.Move();
            george.Move();
            r2.Move();

            Console.WriteLine("\r\n Base on current context, new behaviors: " +
                              "\r\n\t'Big Robot' gets really scared" +
                              "\r\n\t, 'George v.2.1' becomes really mad because" +
                              "it's always attacked by other robots" +
                              "\r\n\t and R2 keeps its calm\r\n");

            bigRobot.Behaviour = new DefensiveBehaviour();
            george.Behaviour = new AgressiveBehaviour();

            bigRobot.Move();
            george.Move();
            r2.Move();
        }
    }
}