using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;

namespace SnakesAndLadders
{
    public class Board
    {
        public readonly Token Token;
        private readonly IEnumerable<Ladder> _ladders;
        private readonly IEnumerable<Snake> _snakes;
        private readonly Random _dice;

        public Board(Token token) : this(token, new Snake[] { }, new Ladder[] { }) { }

        public Board(Token token, IEnumerable<Snake> snakes, IEnumerable<Ladder> ladders)
        {
            Token = token;
            _ladders = ladders ?? new Ladder[] { };
            _snakes = snakes ?? new Snake[] { };
            _dice = new Random();
        }

        public bool PlayerHasWon { get; internal set; }

        public int RollDice()
        {
            var value = _dice.Next(1, 7);
            return value;
        }

        public int RollDiceAndMoveToken()
        {
            var dieValue = RollDice();

            MoveToken(dieValue);

            return dieValue;
        }

        public void MoveToken(int spacesToMove)
        {
            Token.Move(spacesToMove);

            var snake = _snakes.SingleOrDefault(x => x.End == Token.CurrentSquare);
            var ladder = _ladders.SingleOrDefault(x => x.Start == Token.CurrentSquare);

            if (snake != null)
            {
                Token.Move((snake.End - snake.Start) * -1);
            }

            if (ladder != null)
            {
                Token.Move(ladder.End - ladder.Start);
            }
            
            if (Token.CurrentSquare == 100)
            {
                PlayerHasWon = true;
            }
        }
    }
}