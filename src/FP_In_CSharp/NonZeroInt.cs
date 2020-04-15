using System;

namespace FP_In_CSharp
{
    struct NonZeroInt
    {
        public int Value { get; }

        public NonZeroInt(int value)
        {
            if (value == 0)
            {
                throw new ArgumentException("Value cannot be 0");
            }
            Value = value;
        }

        public static implicit operator int(NonZeroInt nonZeroInt)
        {
            return nonZeroInt.Value;
        }
    }
}
