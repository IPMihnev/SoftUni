using System;

namespace ValidationAttributes.Models
{
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool Isvalid(object obs);
    }
}
