using System;

namespace AmountSplitterLibrary
{
    public class AmountSplitter
    {
        public static decimal SplitAmount(decimal amount, int numberOfPeople)
        {
            if (numberOfPeople <= 0)
                throw new ArgumentException("Number of people must be greater than zero.");

            return Math.Round(amount / numberOfPeople, 2);
        }
    }
}