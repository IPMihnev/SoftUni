namespace FactoryMethodPattern.Contracts.Factories
{
    public class EuropeFactory : IAnimalFactory
    {
        public ICarnivore GetCarnivore()
        {
            return new Bear();
        }
    }
}
