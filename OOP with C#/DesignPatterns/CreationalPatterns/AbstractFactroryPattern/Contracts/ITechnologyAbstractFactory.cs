namespace AbstractFactoryPattern.Contracts
{
    interface ITechnologyAbstractFactory
    {
        IMobilePhone CreatePhone();

        ITablet CreateTablet();
    }
}
