using System;

namespace ConsoleApplication1.Strategy
{
    public class GenericRobot<TBehavior>
        where TBehavior : IBehaviour, new()
    {
        private readonly IBehaviour behaviour;
        private String name;

        public GenericRobot(String name)
        {
            this.name = name;
            behaviour = new TBehavior();
        }

        public IBehaviour Behaviour
        {
            get { return behaviour; }
        }

        public void Move()
        {
            Console.WriteLine(this.name + ": Based on current position " +
                              "the behavior decides the next Move:");
            int command = behaviour.Move();
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }
    }

    // the client does not need to know about the behaviors. It can directly use the AgresiveRobot
    public class AggressiveRobot : GenericRobot<AgressiveBehaviour>
    {
        public AggressiveRobot(string name)
            : base(name)
        {
        }
    }
}