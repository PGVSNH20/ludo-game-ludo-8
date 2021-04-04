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
            //Arrange
            int result = Dice.RollDice();

            //Act & Assert
            Assert.IsTrue(result >= 1 && result <= 6);
        }


        [TestMethod]
        public void WhenSettingAmountOfPlayersExpectNumberBetween2and4()
        {
            //Arrange
            


            //Act


        //Assert
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




