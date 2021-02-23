using System;
using System.Collections.Generic;
using System.Threading;
using ConsoleSnakeGame.Helpers;
using ConsoleSnakeGame.Interfaces;

namespace ConsoleSnakeGame
{
    public class GameEngine
    {
        private bool IsStarted = false;
        private List<IDrawable> gameItems = new List<IDrawable>();
        private Random rand = new Random();
        public Snake Snake { get; set; }

        public GameEngine()
        {
            Snake = new Snake(new Position(30, 20), SpawnFood);
            gameItems.Add(Snake);
            for (int i = 0; i < 10; i++)
            {
                SpawnFood();
            }
        }

        public void Start()
        {
            IsStarted = true;
            Position movement = new Position(0, 0);

            while (IsStarted == true)
            {
                BoundariesChecker.CheckBoundaries(Snake.SnakeBody.Head.Value, movement);
                Snake.Move(movement);
                if (Snake.CheckSelfEaten())
                {
                    Console.Clear();
                    ConsoleHelper.Write(new Position((Console.WindowWidth / 2) - 12, (Console.WindowHeight / 2) - 1), "Game Over :( \n");
                    IsStarted = false;
                    break;
                }
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    movement = ReadUserInput.GetMovement(key, movement);
                }
                Thread.Sleep(70);
                gameItems.ForEach(i => i.Draw());
            }
        }

        public void Stop()
        {
            IsStarted = false;
        }

        private void SpawnFood()
        {
            var food = new Food(new Position(
                rand.Next(0, Console.WindowWidth - 1),
                rand.Next(0, Console.WindowHeight - 1)));

            gameItems.Add(food);
            Snake.Foods.Add(food);
        }
    }
}
