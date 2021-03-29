using System;

namespace Assignment03
{
    public class Monkey : IAnimal
    {
        private int healthPoints;
        public Monkey(int healthPoints)
        {
            this.HealthPoints = healthPoints;
        }
        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Health points are not valid.");
                }

                this.healthPoints = value;
            }
        }

        public void Hunger(int amount)
        {
            this.healthPoints -= amount;
        }

        public void Feed(int amount)
        {
            if (this.healthPoints + amount > 100)
            {
                return;
            }
            this.healthPoints += amount;
        }

        public int Status()
        {
            if (this.HealthPoints < 40)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
