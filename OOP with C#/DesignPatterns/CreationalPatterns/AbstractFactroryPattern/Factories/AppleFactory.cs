using AbstractFactoryPattern.Apple;
using AbstractFactoryPattern.Contracts;

namespace AbstractFactoryPattern.Factories
{
    public class AppleFactory : ITechnologyAbstractFactory
    {
        public IMobilePhone CreatePhone()
        {
            return new ApplePhone();
        }

        public ITablet CreateTablet()
        {
            return new AppleTablet();
        }
    }
}
