using System;

namespace ConsoleDemo.AbstractFactory
{
    /// <summary>
    ///     ClientApp startup class for Real-World
    ///     Abstract Factory Design Pattern.
    /// </summary>
    class ClientApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        public static void RunAbstractFactoryDemo()
        {
            // Create and run the African animal world
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);

			Console.Write("In Africa: ");
			 world.RunFoodChain();

            // Create and run the American animal world
            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);

			Console.Write("In Amerca: ");
			world.RunFoodChain();
        }
    }


    /// <summary>
    ///     The 'AbstractFactory' abstract class
    /// </summary>
    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    /// <summary>
    ///     The 'ConcreteFactory1' class
    /// </summary>
    class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeast();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    /// <summary>
    ///     The 'ConcreteFactory2' class
    /// </summary>
    class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    /// <summary>
    ///     The 'AbstractProductA' abstract class
    /// </summary>
    abstract class Herbivore
    {
    }

    /// <summary>
    ///     The 'AbstractProductB' abstract class
    /// </summary>
    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    /// <summary>
    ///     The 'ProductA1' class
    /// </summary>
    class Wildebeast : Herbivore
    {
    }

    /// <summary>
    ///     The 'ProductB1' class
    /// </summary>
    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest
            Console.WriteLine(GetType().Name +
                              " eats " + h.GetType().Name);
        }
    }

    /// <summary>
    ///     The 'ProductA2' class
    /// </summary>
    class Bison : Herbivore
    {
    }

    /// <summary>
    ///     The 'ProductB2' class
    /// </summary>
    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison
            Console.WriteLine(GetType().Name +
                              " eats " + h.GetType().Name);
        }
    }
}