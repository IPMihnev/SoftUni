﻿using System;

namespace ConsoleSnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;
            var engine = new GameEngine();
            engine.Start();
        }
    }
}
