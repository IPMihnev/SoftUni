using AbstractFactoryPattern.Contracts;
using AbstractFactoryPattern.Samsung;

namespace AbstractFactoryPattern.Factories
{
    public class SamsungFactory : ITechnologyAbstractFactory
    {
        public IMobilePhone CreatePhone()
        {
            return new SamsungPhone();
        }

        public ITablet CreateTablet()
        {
            return new SamsungTablet();
        }
    }
}
