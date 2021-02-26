namespace FactoryMethodPattern.Contracts.Factories
{
    public class AfricaFactory : IAnimalFactory
    {
        public ICarnivore GetCarnivore()
        {
            return new Lion();
        }
    }
}
