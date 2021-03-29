namespace Assignment02
{
    public interface IOfferService
    {
        void Add(decimal monthlyFee, int newContractsForMonth, int sameContractsForMonth, int CancelledContractsForMonth);
    }
}
