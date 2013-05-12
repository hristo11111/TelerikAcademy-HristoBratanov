using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace TestPoker
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void TestToStringNoCards()
        {
            IList<ICard> cards = new List<ICard>();

            Hand hand = new Hand(cards);
            string expected = string.Empty;
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToStringTwoCards()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Clubs)
            };

            Hand hand = new Hand(cards);
            string expected = "2♦ 6♣";
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToStringFiveCards_1()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            };

            Hand hand = new Hand(cards);
            string expected = "2♦ 6♣ 10♥ J♠ A♦";
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToStringFiveCards_2()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            };

            Hand hand = new Hand(cards);
            string expected = "K♦ 6♣ 10♥ Q♠ A♦";
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }

    }
}
