using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace TestPoker
{
    [TestClass]
    public class PokerCardTests
    {
        [TestMethod]
        public void TestToStringKingDiamonds()
        {
            Card card = new Card(CardFace.King, CardSuit.Diamonds);
            string expected = "K♦";
            string actual = card.Face.ToString()[0] + "♦";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToStringAceSpades()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            string expected = "A♠";
            string actual = card.Face.ToString()[0] + "♠";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToStringFiveClubs()
        {
            Card card = new Card(CardFace.Five, CardSuit.Clubs);
            string expected = "5♣";
            string actual = ((int)card.Face).ToString() + "♣";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToStringQueenDiamonds()
        {
            Card card = new Card(CardFace.Queen, CardSuit.Diamonds);
            string expected = "Q♦";
            string actual = card.Face.ToString()[0] + "♦";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToStringJackDiamonds()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Diamonds);
            string expected = "J♦";
            string actual = card.Face.ToString()[0] + "♦";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToStringTenHearts()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Diamonds);
            string expected = "10♥";
            string actual = ((int)card.Face).ToString() + "♥";
            Assert.AreEqual(expected, actual);
        }
    }
}
