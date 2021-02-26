using AbstractFactoryPattern.Contracts;

namespace AbstractFactoryPattern.Apple
{
    class AppleTablet : ITablet
    {
        public string OS { get; set; }
    }
}
