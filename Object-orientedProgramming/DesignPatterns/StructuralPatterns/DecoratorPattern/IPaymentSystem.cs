namespace DecoratorPattern
{
    public interface IPaymentSystem
    {
        void PayMoney(string from, string to, int amount);
        void LoanMoney(string from, string to, int amount);
    }
}
