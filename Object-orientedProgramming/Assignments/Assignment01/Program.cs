using System;

namespace Assignment01
{
    class Program
    {
        static void Main(string[] args)
        {
            // The program is using decimal types for precision.

            decimal monthlyTax = decimal.Parse(Console.ReadLine());
            decimal smsCount = decimal.Parse(Console.ReadLine());
            decimal mmsCount = decimal.Parse(Console.ReadLine());
            decimal a1Minutes = decimal.Parse(Console.ReadLine());
            decimal telenorMinutes = decimal.Parse(Console.ReadLine());
            decimal vivacomMinutes = decimal.Parse(Console.ReadLine());
            decimal roamingMinutes = decimal.Parse(Console.ReadLine());
            decimal countryMB = decimal.Parse(Console.ReadLine());
            decimal euMB = decimal.Parse(Console.ReadLine());
            decimal abroadMB = decimal.Parse(Console.ReadLine());
            decimal otherTaxes = decimal.Parse(Console.ReadLine());
            decimal discount = decimal.Parse(Console.ReadLine());
            decimal totalPrice = 0;

            totalPrice += monthlyTax;

            decimal smsPrice = 0;
            if (smsCount > 0 && smsCount < 50)
            {
                smsPrice = smsCount * 0.18m;
            }
            else if (smsCount >= 50 && smsCount <= 100)
            {
                smsPrice = smsCount * 0.16m;
            }
            else if (smsCount > 100)
            {
                smsPrice = smsCount * 0.11m;
            }
            totalPrice += smsPrice;

            decimal mmsPrice = 0;
            if (mmsPrice > 0 && mmsPrice < 50)
            {
                mmsPrice = mmsCount * 0.25m;
            }
            else if (mmsCount >= 50 && mmsCount <= 100)
            {
                mmsPrice = mmsCount * 0.23m;
            }
            else if (mmsCount > 100)
            {
                mmsPrice = mmsCount * 0.18m;
            }
            totalPrice += mmsPrice;
            totalPrice += a1Minutes * 0.03m;
            totalPrice += telenorMinutes * 0.09m;
            totalPrice += vivacomMinutes * 0.09m;
            totalPrice += roamingMinutes * 0.15m;
            totalPrice += countryMB * 0.02m;
            totalPrice += euMB * 0.05m;
            totalPrice += abroadMB * 0.20m;
            totalPrice += otherTaxes;
            totalPrice -= discount;

            Console.WriteLine($"Result: {totalPrice:f2}");
        }
    }
}
