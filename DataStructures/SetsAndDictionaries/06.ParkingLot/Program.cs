using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] info = input.Split(", ");
                if (info[0] == "IN")
                {
                    cars.Add(info[1]);
                }
                else if (info[0] == "OUT")
                {
                    if (cars.Contains(info[1]))
                    {
                        cars.Remove(info[1]);
                    }
                }
            }
            if (cars.Count > 0)
            {
                foreach (var item in cars)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
