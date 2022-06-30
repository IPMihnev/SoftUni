using System;
using Task2.Models;

namespace Task2
{
    class Program
    {
        // New taxes can be applyed by creating new interfaces which can be implemented by the GrossAmount class.
        static void Main()
        {
            Console.WriteLine("Enter gross salary...");
            decimal gross = decimal.Parse(Console.ReadLine());
            var grossAmount = new GrossAmount(gross);
            Console.WriteLine($"Your net salary by the taxation rules of the country of Imaginaria is {grossAmount.GetNetAmount()} IDR.");
        }
    }
}
