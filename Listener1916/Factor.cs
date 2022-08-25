using System;
namespace Listener1916
{
    public class Factor : IComparable
    {
        public long Number { get; set; }
        public int NumLength { get; set; }
        public int FactorCount { get; set; }

        public Factor(long number)
        {
            Number = number;
            FactorCount = CountFactors(Number);

            NumLength = (int)Math.Log10(Number) + 1;
        }

        public Factor ( long number, int count)
        {
            Number = number;
            FactorCount = count;

            NumLength = (int)Math.Log10(Number) + 1;
        }

        public override string ToString()
        {
            return $"{Number,6} ({FactorCount,2},{NumLength,2})";
        }

        private int CountFactors(long number)
        {
            int retval = 0;

            for (int i = 1; i  <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    retval++;
                    if (number / i != i)
                        retval++;
                }
            }
            return retval;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            Factor? otherNumber = obj as Factor;
            if (otherNumber != null)
                return this.Number.CompareTo(otherNumber.Number);
            else
                throw new ArgumentException("Number is not a Factor");
        }
    }
}

