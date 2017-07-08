using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WarCardGame.UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Player1Wins()
        {
            var decks = new[]
            {
                new List<IComparable> {5, 1, 13, 10, 11, 3, 2, 10, 4, 12, 5, 11, 10, 5, 7, 6, 6, 11, 9, 6, 3, 13, 6, 1, 8, 1},
                new List<IComparable> {9, 12, 8, 3, 11, 10, 1, 4, 2, 4, 7, 9, 13, 8, 2, 13, 7, 4, 2, 8, 9, 12, 3, 12, 7, 5}
            };
            var winner = WarCardGame.Play(decks[0], decks[1]);
            Assert.AreEqual(1, winner);
        }
        [TestMethod]
        public void Player2Wins()
        {
            var decks = new[]
            {
                new List<IComparable> {3, 11, 6, 12, 2, 13, 5, 7, 10, 3, 10, 4, 12, 11, 1, 13, 12, 2, 1, 7, 10, 6, 12, 5, 8, 1},
                new List<IComparable> {9, 10, 7, 9, 5, 2, 6, 1, 11, 11, 7, 9, 3, 4, 8, 3, 4, 8, 8, 4, 6, 9, 13, 2, 13, 5}
            };
            var winner = WarCardGame.Play(decks[0], decks[1]);
            Assert.AreEqual(2, winner);
        }
        [TestMethod]
        public void PlayersDraw()
        {
            var decks = new[]
            {
                new List<IComparable> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13},
                new List<IComparable> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}
            };
            var winner = WarCardGame.Play(decks[0], decks[1]);
            Assert.AreEqual(0, winner);
        }
    }
}
