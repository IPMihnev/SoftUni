using FactoryMethodPattern.Contracts;

namespace FactoryMethodPattern
{
    public interface IAnimalFactory
    {
        public ICarnivore GetCarnivore();
    }
}
