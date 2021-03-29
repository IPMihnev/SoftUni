namespace Assignment03
{
    public interface IAnimal
    {
        int HealthPoints { get; }

        void Hunger(int amount);

        void Feed(int amount);

        int Status();
    }
}
