using System;
using AbstractFactoryPattern.Contracts;
using AbstractFactoryPattern.Factories;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select tech brand:...");

            string brand = Console.ReadLine();

            ITechnologyAbstractFactory techFactory = null;

            if (brand == "Apple")
            {
                techFactory = new AppleFactory();
            }
            else if (brand == "Samsung")
            {
                techFactory = new SamsungFactory();
            }

            IMobilePhone myPhone = techFactory.CreatePhone();

            ITablet myTablet = techFactory.CreateTablet();
        }
    }
}
