using System;

namespace ConsoleApplication1.Strategy
{
    public abstract class Robot_
    {
        private String name;

        public Robot_(String name)
        {
            this.name = name;
        }

        public abstract int Move();

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }
    }

    internal class AgresiveRobot_ : Robot_
    {
        public AgresiveRobot_(string name) : base(name)
        {
        }

        public override int Move()
        {
            Console.WriteLine("\tAgressive Behaviour: if find another robot attack it");
            return 1;
        }
    }

    public class DefensiveRobot_ : Robot_
    {
        public DefensiveRobot_(string name) : base(name)
        {
        }

        public override int Move()
        {
            Console.WriteLine("\tDefensive Behaviour: if find another robot run from it");
            return -1;
        }
    }

    public class NormalRobot_ : Robot_
    {
        public NormalRobot_(string name) : base(name)
        {
        }

        public override int Move()
        {
            Console.WriteLine("\tNormal Behaviour: if find another robot ignore it");
            return 0;
        }
    }
}