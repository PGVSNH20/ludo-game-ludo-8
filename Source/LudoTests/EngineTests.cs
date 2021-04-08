using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LudoTests
{
    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void WhenRollingDiceExpectNumberBetween1and6()
        {
            Assert.IsTrue(Dice.Roll() >= 1 && Dice.Roll() <= 6);
        }

        [TestMethod]
        public void WhenComparingCoordinatesExpectTrue()
        {
            Position TestPosition = new Position(10, 10);

            Assert.IsTrue(TestPosition.Compare(new Position(10, 10)));
        }
    }
}




// Arrange
//
// The Arrange section of a unit test method initializes objects and sets the value of the data that is passed to the method under test.

// Act
//
// The Act section invokes the method under test with the arranged parameters.

// Assert
//
// The Assert section verifies that the action of the method under test behaves as expected.




