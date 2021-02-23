using ConsoleSnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using ConsoleSnakeGame.Helpers;

namespace ConsoleSnakeGame
{
    public class Snake : IDrawable
    {
        public Snake(Position headPosition, Action spawnFood)
        {
            SnakeBody = new LinkedList();
            SnakeBody.AddHead(new Node(headPosition));
            Foods = new List<Food>();
            this.SpawnFood = spawnFood;
            for (int i = 1; i <= 3; i++)
            {
                SnakeBody.AddLast(new Node(
                                    new Position(
                        headPosition.X + i, headPosition.Y)));
            }
        }

        public Action SpawnFood { get; set; }
        public LinkedList SnakeBody { get; set; }
        public List<Food> Foods { get; set; }

        public bool CheckSelfEaten()
        {
            HashSet<Position> set = new HashSet<Position>();
            bool IsSelfEaten = false;
            SnakeBody.ForEach(n =>
            {
                if (set.Contains(n.Value))
                {
                    IsSelfEaten = true;
                }

                set.Add(n.Value);
            });
            return IsSelfEaten;
        }
        public void Move(Position position)
        {
            if (position.X == 0 && position.Y == 0)
            {
                return;
            }

            ConsoleHelper.Clear(SnakeBody.Tail.Value);

            SnakeBody.ReverseForEach(n =>
            {
                if (n.Previous != null)
                {
                    n.Value.X = n.Previous.Value.X;
                    n.Value.Y = n.Previous.Value.Y;
                }
            });

            SnakeBody.Head.Value.ChangePosition(position);

            for (int i = 0; i < Foods.Count; i++)
            {
                if (Foods[i].Position == SnakeBody.Head.Value)
                {
                    Foods[i].EatFood();
                    Grow(position);
                    SpawnFood();
                }
            }

        }

        public void Grow(Position position)
        {
            var reversedPosition = new Position(position.X * -1, position.Y * -1);
            var oldPosition = SnakeBody.Tail.Value;
            
            var newHead = new Node(new Position(oldPosition.X, oldPosition.Y));
            newHead.Value.ChangePosition(reversedPosition);
            BoundariesChecker.CheckBoundaries(newHead.Value, reversedPosition);
            SnakeBody.AddLast(newHead);
        }

        public void Draw()
        {
            SnakeBody.ForEach(n =>
            {
                var text = "*";
                if (n == SnakeBody.Head)
                {
                    text = "$";
                }
                ConsoleHelper.Write(n.Value, text);
            });
        }
    }
}
