using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string>(songs);

            while (queue.Count > 0)
            {
                string command = Console.ReadLine();
                if (command.Contains("Play"))
                {
                    queue.Dequeue();
                }
                else if (command.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
                else if (command.Contains("Add"))
                {
                    string[] arr = command.Split("Add ", StringSplitOptions.RemoveEmptyEntries);
                    string newSong = arr[0];
                    if (queue.Contains(newSong))
                    {
                        Console.WriteLine($"{newSong} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(newSong);
                    }
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
