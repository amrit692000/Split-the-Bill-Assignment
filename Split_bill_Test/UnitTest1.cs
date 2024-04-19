using AmountSplitterLibrary;
using TipCalculatorLibrary;

namespace Split_bill_Test

{
    [TestClass]
    public class AmountSplitterTests
    {
        [TestMethod]
        public void SplitAmount_GivenValidInput_ReturnsCorrectAmount()
        {
            // Arrange
            decimal amount = 100;
            int numberOfPeople = 5;

            // Act
            decimal result = AmountSplitter.SplitAmount(amount, numberOfPeople);

            // Assert
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void SplitAmount_GivenZeroNumberOfPeople_ThrowsArgumentException()
        {
            // Arrange
            decimal amount = 100;
            int numberOfPeople = 0;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => AmountSplitter.SplitAmount(amount, numberOfPeople));
        }

        [TestMethod]
        public void SplitAmount_GivenNegativeNumberOfPeople_ThrowsArgumentException()
        {
            // Arrange
            decimal amount = 100;
            int numberOfPeople = -1;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => AmountSplitter.SplitAmount(amount, numberOfPeople));
        }
    }
    [TestClass]
    public class TipCalculatorTests
    {
        [TestMethod]
        public void CalculateTip_GivenValidInput_ReturnsCorrectTipAmounts()
        {
            // Arrange
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Ramesh", 20.50m },
                { "Sunita", 30.75m },
                { "Amit", 25.25m }
            };
            float tipPercentage = 15;

            // Act
            var result = TipCalculator.CalculateTip(mealCosts, tipPercentage);

            // Assert
            Assert.AreEqual(4.58m, result["Ramesh"]);
            Assert.AreEqual(6.88m, result["Sunita"]);
            Assert.AreEqual(5.63m, result["Amit"]);
        }

        [TestMethod]
        public void CalculateTip_GivenNegativeTipPercentage_ThrowsArgumentException()
        {
            // Arrange
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Ramesh", 20.50m },
                { "Sunita", 30.75m },
                { "Amit", 25.25m }
            };
            float tipPercentage = -5;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => TipCalculator.CalculateTip(mealCosts, tipPercentage));
        }

        [TestMethod]
        public void CalculateTip_GivenTipPercentageGreaterThan100_ThrowsArgumentException()
        {
            // Arrange
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Ramesh", 20.50m },
                { "Sunita", 30.75m },
                { "Amit", 25.25m }
            };
            float tipPercentage = 110;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => TipCalculator.CalculateTip(mealCosts, tipPercentage));
        }
    }

}