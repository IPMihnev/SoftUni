using System;

namespace Assignment03
{
    public class Elephant : IAnimal
    {
        private int healthPoints;
        private bool canNotWalk = false;
        private bool isDeath = false;
        public Elephant(int healthPoints)
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
            if (canNotWalk == true)
            {
                isDeath = true;
                return;
            }
            if (this.healthPoints < 70)
            {
                this.canNotWalk = true;
            }
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
            if (isDeath == true)
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
