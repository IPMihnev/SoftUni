using System;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter _commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this._commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                var result = _commandInterpreter.Read(input);

                Console.WriteLine(result);
            }
        }
    }
}
