using System;

namespace BuilderPattern
{
    class CarBuilder : ICarBuilder
    {
        public void BuildTyres(Car car)
        {
            car.Tyres = "Michelin";
        }

        public void BuildEngine(Car car)
        {
            car.Engine = "Best engine";
        }

        public void BuildGearBox(Car car)
        {
            car.GearBox = "Best gearbox";
        }
    }
}
