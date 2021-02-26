using System;

namespace SingletonPattern
{
    public sealed class Logger
    {
        private static Logger instance;
        private static object someLock = new object();
        private Logger() { }

        public void Print()
        {
            System.Console.WriteLine("I print something.");
        }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (someLock)
                    {
                        if (instance == null)
                        {
                            instance = new Logger();
                        }
                    }
                }
                return instance;
            }
        }
    }
}