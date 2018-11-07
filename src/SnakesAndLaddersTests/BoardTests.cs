﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SnakesAndLadders;

namespace SnakesAndLaddersTests
{
    [TestFixture]
    public class BoardTests
    {
        private Board _board;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _board = new Board(new Token());
        }

        [Test, Repeat(18)]
        public void DiceRollsAreWithinRange()
        {
            var result = _board.RollDice();

            Assert.That(result, Is.GreaterThanOrEqualTo(1).And.LessThanOrEqualTo(6));
        }

        [Test]
        public void TokenMovesNumberOfSquaresOnDieRoll()
        {
            var token = new Token();
            var squareBeforeDiceRoll = token.CurrentSquare;
            var board = new Board(token);

            var spacesToMove = board.RollDiceAndMoveToken();

            Assert.That(token.CurrentSquare, Is.EqualTo(squareBeforeDiceRoll + spacesToMove));
        }

        [Test]
        public void PlayerHasWonTheGame()
        {
            var token = new Token();
            token.Move(96);

            var board = new Board(token);

            board.MoveToken(3);

            Assert.That(board.PlayerHasWon, Is.True);
        }

        [Test]
        public void PlayerHasNotWonTheGame()
        {
            var token = new Token();
            token.Move(96);

            var board = new Board(token);

            board.MoveToken(4);
            
            Assert.That(board.PlayerHasWon, Is.False);
        }
    }
}
