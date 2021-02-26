using System;
using CommandPattern.Commands;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            string inputStr = string.Empty;
            while ((inputStr = Console.ReadLine()) != "End")
            {
                string[] input = inputStr.Split();
                int value = int.Parse(input[1]);
                ICommand command = null;
                switch (input[0])
                {
                    case "+":
                        command = new PlusCommand(value);
                        break;
                    case "-":
                        command = new MinusCommand(value);
                        break;
                    case "*":
                        command = new MultiplyCommand(value);
                        break;
                    case "undo":
                        calc.Undo(value);
                        break;
                }

                if (command != null)
                {
                    calc.AddCommand(command);
                }
                Console.WriteLine(calc.Result);
            }
        }
    }
}
