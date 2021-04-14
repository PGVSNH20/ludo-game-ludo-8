using LudoGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LudoTests
{
    [TestClass]
    public class EngineTests
    {
        public Board CreateTestBoard()
        {
            var moves = new List<Move>();
            var players = new List<Player>();
            var player1 = new Player("Frej", Colors.Red, false);
            var playerAi2 = new Player("", Colors.Green, true);
            var player3 = new Player("", Colors.Yellow, false);
            var playerAi4 = new Player("BOT Elmer", Colors.Blue, true);
            players.Add(player1);
            players.Add(playerAi2);
            players.Add(player3);
            players.Add(playerAi4);

            Board game = new Board(players, moves, DateTime.Now);
            return game;
        }

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

        [TestMethod]
        public void WhenRollingSixMoveOutPieceToSixthPos()
        {
            var game = CreateTestBoard();
            var playerArray = game.Players.ToArray();
            Dice.Roll(6);
            playerArray[0].Pieces[0].MoveOut();
            Assert.IsTrue(playerArray[0].Pieces[0].CurrentPosition.Compare(playerArray[0].Pieces[0].SixthPosition));
        }
    }
}