using Assignment02.Data;

namespace Assignment02
{
    public class OfferService : IOfferService
    {
        private readonly ApplicationDbContext dbContext;

        public OfferService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(decimal monthlyFee, int newContractsForMonth, int sameContractsForMonth, int CancelledContractsForMonth)
        {
            var offer = new Offer
            {
                MonthlyFee = monthlyFee,
                NewContractsForMonth = newContractsForMonth,
                SameContractsForMonth = sameContractsForMonth,
                CancelledContractsForMonth = CancelledContractsForMonth,
            };
            dbContext.Offers.Add(offer);
            dbContext.SaveChanges();
        }
    }
}
