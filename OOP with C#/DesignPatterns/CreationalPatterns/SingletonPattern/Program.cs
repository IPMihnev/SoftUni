using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = Logger.Instance;


            logger.Print();
        }
    }
}
