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
        public void WhenAtStartPosAndMoves5StepsExpectSixthPos()
        {
            var game = CreateTestBoard();
            var playerArray = game.Players.ToArray();
            playerArray[0].Pieces[0].CurrentPosition.X = playerArray[0].Pieces[0].StartPosition.X;
            playerArray[0].Pieces[0].CurrentPosition.Y = playerArray[0].Pieces[0].StartPosition.Y;
            Move move = new Move(playerArray[0], 1, Dice.Roll(5), playerArray[0].ID, game.ID);
            game.MovePiece(move, true);
            Assert.IsTrue(playerArray[0].Pieces[0].CurrentPosition.Compare(playerArray[0].Pieces[0].SixthPosition));
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

// Arrange
//
// The Arrange section of a unit test method initializes objects and sets the value of the data that is passed to the method under test.

// Act
//
// The Act section invokes the method under test with the arranged parameters.

// Assert
//
// The Assert section verifies that the action of the method under test behaves as expected.
