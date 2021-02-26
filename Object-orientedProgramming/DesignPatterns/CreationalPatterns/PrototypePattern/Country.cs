using System;

namespace PrototypePattern
{   [Serializable]
    public class Country : ICloneable
    {
        public string Name { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}