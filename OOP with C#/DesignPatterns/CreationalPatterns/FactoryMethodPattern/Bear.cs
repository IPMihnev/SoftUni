using FactoryMethodPattern.Contracts;

namespace FactoryMethodPattern
{
    public class Bear : ICarnivore
    {
        public Bear() { }
        public string AnimalsThatIEat { get; set; }
    }
}
