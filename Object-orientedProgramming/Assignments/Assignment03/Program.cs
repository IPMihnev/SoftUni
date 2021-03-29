using System;
using System.Collections.Generic;

namespace Assignment03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> zoo = new List<IAnimal>();
            for (int i = 0; i < 5; i++)
            {
                zoo.Add(new Monkey(100));
                zoo.Add(new Lion(100));
                zoo.Add(new Elephant(100));
            }

            Hunger(zoo);

            Feed(zoo);

            Console.WriteLine(AnimalsCount(zoo));
        }

        static void Hunger(List<IAnimal> zoo)
        {
            for (int i = 0; i < zoo.Count; i++)
            {
                Random rand = new Random();
                int amount = rand.Next(21);
                var animal = zoo[i];
                animal.Hunger(amount);
                if (animal.Status() == 1)
                {
                    zoo.Remove(animal);
                    i--;
                }
            }
        }

        static void Feed(List<IAnimal> zoo)
        {
            Random rand = new Random(5);
            int monkeysRand = rand.Next(26);
            int lionsRand = rand.Next(26);
            int ElephantsRand = rand.Next(26);

            foreach (var animal in zoo)
            {
                if (animal.GetType() == typeof(Lion))
                {
                    animal.Feed(lionsRand);
                }
                else if (animal.GetType() == typeof(Monkey))
                {
                    animal.Feed(monkeysRand);
                }
                else
                {
                    animal.Feed(ElephantsRand);
                }
            }
        }
        static int AnimalsCount(List<IAnimal> zoo)
        {
            return zoo.Count;
        }
    }
}
