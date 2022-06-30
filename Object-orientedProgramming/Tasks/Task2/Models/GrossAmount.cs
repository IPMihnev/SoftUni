using Task2.Interfaces;

namespace Task2.Models
{
    class GrossAmount : ITaxable, ISocialContributable
    {
        public decimal Amount { get; set; }
        public GrossAmount(decimal amount)
        {
            this.Amount = amount;
        }

        public decimal GetNetAmount()
            => this.Amount -= (GetTaxFromAmount() + GetSocialContribution());

        public decimal GetTaxFromAmount()
        {
            if (this.Amount <= 1000m)
            {
                return 0;
            }
            var excessAmount = this.Amount - 1000m;
            var excessAmountTax = excessAmount * 0.10m;
            return excessAmountTax;
        }
        public decimal GetSocialContribution()
        {
            if (this.Amount <= 1000m)
            {
                return 0;
            }
            var excessAmount = this.Amount - 1000m;
            if (this.Amount > 3000m)
            {
                excessAmount -= this.Amount - 3000m;
            }
            return excessAmount *= 0.15m;
        }
    }
}
