using System;
using FactoryMethodPattern.Contracts;
using FactoryMethodPattern.Contracts.Factories;

namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What continent are we?");
            string continent = Console.ReadLine();

            IAnimalFactory factory = new EuropeFactory();
            if (continent == "Africa")
            {
                factory = new AfricaFactory();
            }

            ICarnivore animal = factory.GetCarnivore();
        }
    }
}
