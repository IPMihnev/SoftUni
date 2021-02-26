using System;

namespace SimpleFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnimal lion = AnimalFactory.AnimalCreator("Lion");

            Console.WriteLine(lion.GetType().Name);
        }
    }
}
