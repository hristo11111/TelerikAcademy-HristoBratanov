using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int handCount = 5;

        public bool IsValidHand(IHand hand)
        {
            bool hasDuplicate = false;
            if (hand.Cards.Count < handCount)
            {
                return false;
            }
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (!hasDuplicate)
                {
                    ICard cardToCheck = hand.Cards[i];
                    for (int j = i + 1; j < hand.Cards.Count; j++)
                    {
                        if (cardToCheck.ToString() == hand.Cards[j].ToString())
                        {
                            hasDuplicate = true;
                            break;
                        }
                    } 
                }
                else
                {
                    break;
                }
            }

            return !hasDuplicate;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (hand.Cards.Count < handCount)
            {
                return false;
            }

            bool areFourOfAKind = false;
            List<ICard> sortedHand = (List<ICard>)(hand.Cards.OrderBy(x => x.Face).ToList());

            if (sortedHand[0].Face.Equals(sortedHand[1].Face) &&
                sortedHand[1].Face.Equals(sortedHand[2].Face) &&
                sortedHand[2].Face.Equals(sortedHand[3].Face) &&
                sortedHand[3].Face.CompareTo(sortedHand[4].Face) != 0)
            {
                if (sortedHand[0].Suit.Equals(sortedHand[1].Suit) ||
                    sortedHand[1].Suit.Equals(sortedHand[2].Suit) ||
                    sortedHand[2].Suit.Equals(sortedHand[3].Suit))
                {
                    areFourOfAKind = false;
                }
                else
                {
                    areFourOfAKind = true;
                }
            }
            else if (sortedHand[0].Face.CompareTo(sortedHand[1].Face) != 0 &&
                sortedHand[1].Face.Equals(sortedHand[2].Face) &&
                sortedHand[2].Face.Equals(sortedHand[3].Face) &&
                sortedHand[3].Face.Equals(sortedHand[4].Face))
            {
                if (sortedHand[1].Suit.Equals(sortedHand[2].Suit) ||
                    sortedHand[2].Suit.Equals(sortedHand[3].Suit) ||
                    sortedHand[3].Suit.Equals(sortedHand[4].Suit))
                {
                    areFourOfAKind = false;
                }
                else
                {
                    areFourOfAKind = true;
                }
            }

            return areFourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            if (hand.Cards.Count < handCount)
            {
                return false;
            }

            bool sameSuit = false;
            if (hand.Cards[0].Suit.Equals(hand.Cards[1].Suit) &&
                hand.Cards[1].Suit.Equals(hand.Cards[2].Suit) &&
                hand.Cards[2].Suit.Equals(hand.Cards[3].Suit) &&
                hand.Cards[3].Suit.Equals(hand.Cards[4].Suit))
            {
                sameSuit = true;
            }

            int[] faces = new int[5];
            bool isSequence = true;
            if (sameSuit)
            {
                for (int i = 0; i < hand.Cards.Count; i++)
                {
                    faces[i] = (int)hand.Cards[i].Face;
                }

                Array.Sort(faces);
                for (int i = 0; i < faces.Length - 1; i++)
                {
                    if (faces[i] != faces[i + 1] - 1)
                    {
                        isSequence = false;
                    }
                }
            }

            if (sameSuit == true && isSequence == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
