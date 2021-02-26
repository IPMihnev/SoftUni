using System;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Country country = new Country() { Name = "Germany" };
            City city = new City() { Name = "Berlin" };
            Address address = new Address() { Street = "Schtrasse 5" };
            address.City = city;
            address.Country = country;

            Address prototypedAddress = address.Clone() as Address;
            prototypedAddress.Street = "Hauptschtr. 1";
            prototypedAddress.City = new City() { Name = "Munich" };

            Console.WriteLine(address);
            Console.WriteLine(prototypedAddress);
        }
    }
}
