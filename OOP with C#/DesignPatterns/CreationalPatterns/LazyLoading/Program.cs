using System;

namespace LazyLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            Lazy<Cart> cart = new Lazy<Cart>();
            Console.WriteLine("Hello World!");
            
            Console.WriteLine(cart.IsValueCreated);
            cart.Value.Balance = 50;
            Console.WriteLine(cart.IsValueCreated);
        }
    }
}
