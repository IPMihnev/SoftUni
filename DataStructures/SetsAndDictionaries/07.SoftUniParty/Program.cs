using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIP = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    VIP.Add(input);
                }
                else
                {
                    regular.Add(input);
                }
            }
            while ((input = Console.ReadLine()) != "END")
            {
                if (char.IsDigit(input[0]))
                {
                    if (VIP.Contains(input))
                    {
                        VIP.Remove(input);
                    }
                }
                else
                {
                    if (regular.Contains(input))
                    {
                        regular.Remove(input);
                    }
                }
            }
            Console.WriteLine(VIP.Count + regular.Count);
            if (VIP.Count > 0)
            {
                foreach (var item in VIP)
                {
                    Console.WriteLine(item);
                }
            }
            if (regular.Count > 0)
            {
                foreach (var item in regular)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
