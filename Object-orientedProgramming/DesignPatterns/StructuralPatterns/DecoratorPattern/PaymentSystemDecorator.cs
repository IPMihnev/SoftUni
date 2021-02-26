using System;

namespace DecoratorPattern
{
    class PaymentSystemDecorator : IPaymentSystem
    {
        private IPaymentSystem paymentSystem;

        public PaymentSystemDecorator(IPaymentSystem paymentSystem)
        {
            this.paymentSystem = paymentSystem;
        }


        public void PayMoney(string from, string to, int amount)
        {
            paymentSystem.PayMoney(from, to, amount);
            Console.WriteLine("Payment added into DataBase system.");
        }

        public void LoanMoney(string from, string to, int amount)
        {
            paymentSystem.LoanMoney(from, to, amount);
            Console.WriteLine("Loan added into DataBase system.");
        }
    }
}
