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
            var dice = new Dice();
            int result = dice.RollDice();
            Assert.IsTrue(result >= 1 && result <= 6);
        }
    }
}
