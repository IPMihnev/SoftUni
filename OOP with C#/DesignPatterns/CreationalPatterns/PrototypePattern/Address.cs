using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PrototypePattern
{
    [Serializable]
    class Address : ICloneable
    {
        public City City { get; set; }

        public Country Country { get; set; }

        public string Street { get; set; }

        public object Clone()
        {
            return DeepClone<Address>(this);
        }

        //This is a method for Deep Copy with Binary Serialization Formatter and not just Shallow Copy.
        public static T DeepClone<T>(T obj)
        {
            using var ms = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;
            return (T)formatter.Deserialize(ms);
        }

        public override string ToString()
        {
            return $"Country {Country.Name}, City {City.Name}, Address {Street}";
        }
    }
}
