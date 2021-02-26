namespace BuilderPattern
{
    interface ICarBuilder
    {
        void BuildTyres(Car car);

        void BuildEngine(Car car);

        void BuildGearBox(Car car);
    }
}
