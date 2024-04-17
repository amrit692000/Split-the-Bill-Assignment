using System;
using System.Collections.Generic;

namespace TipCalculatorLibrary
{
    public class TipCalculator
    {
        public static Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            if (tipPercentage < 0 || tipPercentage > 100)
                throw new ArgumentException("Tip percentage must be between 0 and 100.");

            var tipAmounts = new Dictionary<string, decimal>();
            decimal totalCost = 0;

            foreach (var kvp in mealCosts)
                totalCost += kvp.Value;

            decimal totalTip = totalCost * (decimal)(tipPercentage / 100);

            foreach (var kvp in mealCosts)
            {
                decimal individualTip = kvp.Value / totalCost * totalTip;
                tipAmounts.Add(kvp.Key, Math.Round(individualTip, 2));
            }

            return tipAmounts;
        }
    }
}