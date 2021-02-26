using System;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            CarBuilder builder = new CarBuilder();

            builder.BuildEngine(car);
            builder.BuildGearBox(car);
            builder.BuildTyres(car);

            Console.WriteLine(car.Engine + ' ' + car.Tyres);
        }
    }
}
