using System;

namespace ValidationAttributes.Models
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int _min;
        private int _max;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this._min = minValue;
            this._max = maxValue;
        }
        public override bool Isvalid(object obj)
        {
            if (!(obj is int))
            {
                throw new ArgumentException();
            }

            int valueAsInt = (int) obj;

            if (valueAsInt >= _min && valueAsInt <= _max)
            {
                return true;
            }

            return false;
        }
    }
}
