using FactoryMethodPattern.Contracts;

namespace FactoryMethodPattern
{
    public class Lion : ICarnivore
    {
        public Lion() { }
        public string AnimalsThatIEat { get; set; }
    }
}
