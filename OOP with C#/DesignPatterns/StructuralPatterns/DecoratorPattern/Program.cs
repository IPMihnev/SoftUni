namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IPaymentSystem paymentSys = new PaymentSystemDecorator(new PaymentSystem());

            paymentSys.LoanMoney("John", "Jack", 100);

            paymentSys.PayMoney("Jessica", "Lisa", 20);

        }
    }
}
