using System;

namespace SnakesAndLadders
{
    public class Board
    {
        public readonly Token Token;
        private readonly Random _dice;

        public Board(Token token)
        {
            Token = token;
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

            if (Token.CurrentSquare == 100)
            {
                PlayerHasWon = true;
            }
        }
    }
}