using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace TestPoker
{
    [TestClass]
    public class FourOfAKindTests
    {
        [TestMethod]
        public void TestFourOfAKindCorrectHand_1()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestFourOfAKindCorrectHand_2()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestFourOfAKindCorrectHand_3()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestFourOfAKindIncorrectHand_TwoSameCards()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestFourOfAKindIncorrectHand_ThreeSameFaces()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestFourOfAKindIncorrectHand_FiveSameFaces()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestFourOfAKindIncorrectHand_FourSameCards()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestFourOfAKindLessCards()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }
    }
}
