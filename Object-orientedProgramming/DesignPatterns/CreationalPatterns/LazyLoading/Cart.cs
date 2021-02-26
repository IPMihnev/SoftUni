using System;

namespace LazyLoading
{
    public class Cart
    {
        public Cart()
        {
            Console.WriteLine("Initialized");
        }

        public int Balance { get; set; }
    }
}
