using System;

namespace ConsoleDemo.Strategy
{
    public interface IBehaviour
    {
        int Move();
    }

    public class AgressiveBehaviour : IBehaviour
    {
        public int Move()
        {
            Console.WriteLine("\tAgressive Behaviour: if find another robot attack it");
            return 1;
        }
    }

    public class DefensiveBehaviour : IBehaviour
    {
        public int Move()
        {
            Console.WriteLine("\tDefensive Behaviour: if find another robot run from it");
            return -1;
        }
    }

    public class NormalBehaviour : IBehaviour
    {
        public int Move()
        {
            Console.WriteLine("\tNormal Behaviour: if find another robot ignore it");
            return 0;
        }
    }

    public class Robot
    {
        private IBehaviour behaviour;
        private String name;

        public Robot(String name)
        {
            this.name = name;
        }

        public IBehaviour Behaviour
        {
            get { return behaviour; }
            set { this.behaviour = value; }
        }

        public void Move()
        {
            Console.WriteLine(this.name + ": Based on current position " +
                                        "the behavior decides the next Move:"); 
            int command = behaviour.Move();

            ExecuteCommand(command);
        }

        private void ExecuteCommand(int command)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }
    }


   
}