using System;

namespace DecoratorPattern
{
    class PaymentSystem : IPaymentSystem
    {
        public void PayMoney(string from, string to, int amount)
        {
            Console.WriteLine($"Paid {amount} money {from} to {to}.");
        }

        public void LoanMoney(string from, string to, int amount)
        {
            Console.WriteLine($"Loaned {amount} money {from} to {to}.");

        }
    }
}
