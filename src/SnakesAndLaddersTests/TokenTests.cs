using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SnakesAndLadders;

namespace SnakesAndLaddersTests
{
    [TestFixture]
    public class TokenTests
    {
        [Test]
        public void TokenStartsOnSquareOne()
        {
            var token = new Token();

            Assert.That(token.CurrentSquare, Is.EqualTo(1));
        }

        [Test]
        public void TokenIsMovedOnce()
        {
            var token = new Token();

            token.Move(3);

            Assert.That(token.CurrentSquare, Is.EqualTo(4));
        }

        [Test]
        public void TokenIsMovedTwice()
        {
            var token = new Token();

            token.Move(3);
            token.Move(4);

            Assert.That(token.CurrentSquare, Is.EqualTo(8));
        }
    }
}
