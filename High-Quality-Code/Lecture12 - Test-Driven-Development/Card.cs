using System;
using System.Text;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(GetCardFace());
            result.Append(GetCardSuit());

            return result.ToString();

        }

        private string GetCardFace()
        {
            string face;

            if ((int)this.Face <= 10)
            {
                face = ((int)this.Face).ToString();
            }
            else
            {
                switch (this.Face)
                {
                    case CardFace.Jack: face = "J";
                        break;
                    case CardFace.Queen: face = "Q";
                        break;
                    case CardFace.King: face = "K";
                        break;
                    case CardFace.Ace: face = "A";
                        break;
                    default: throw new ArgumentException("There is no such carface!");
                }
            }

            return face;
        }

        private char GetCardSuit()
        {
            char suit;

            switch (this.Suit)  
            {
                case CardSuit.Clubs: suit = '♣';
                    break;
                case CardSuit.Diamonds: suit = '♦';
                    break;
                case CardSuit.Hearts: suit = '♥';
                    break;
                case CardSuit.Spades: suit = '♠';
                    break;
                default: throw new ArgumentException("There is no such card suit!");
            }

            return suit;
        }
    }
}
