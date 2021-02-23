using System;
using ConsoleSnakeGame.Helpers;
using ConsoleSnakeGame.Interfaces;

namespace ConsoleSnakeGame
{
    public class Food : IDrawable
    {
        private bool IsEaten = false;
        public Food(Position position, char symbol = '#')
        {
            this.Position = position;
            this.Symbol = symbol;
        }
        public Position Position { get; set; }
        public char Symbol { get; set; }
        public void EatFood()
        {
            ConsoleHelper.Clear(Position);
            IsEaten = true;
        }
        public void Draw()
        {
            if (IsEaten == false)
            {
                ConsoleHelper.Write(Position,Symbol.ToString());
            }
        }
    }
}
