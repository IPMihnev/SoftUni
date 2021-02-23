using System;

namespace ConsoleSnakeGame
{
    public static class ReadUserInput
    {
        public static Position GetMovement(ConsoleKey key, Position oldMovement)
        {
            Position position = oldMovement;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (oldMovement.Y != 1)
                        position = new Position(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (oldMovement.Y != -1)
                        position = new Position(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (oldMovement.X != 1)
                        position = new Position(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (oldMovement.X != -1)
                        position = new Position(1, 0);
                    break;
            }
            return position;
        }
    }
}
