namespace SimpleFactoryPattern
{
    public class AnimalFactory
    {
        public static IAnimal AnimalCreator(string animal)
        {
            if (animal == "Lion")
            {
                return new Lion();
            }
            if (animal == "Wolf")
            {
                return new Wolf();
            }
            return null;
        }

    }
}
