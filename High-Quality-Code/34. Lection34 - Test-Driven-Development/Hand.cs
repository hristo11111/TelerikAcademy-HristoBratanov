﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            if (this.Cards.Count != 0)
            {
                foreach (ICard card in this.Cards)
                {
                    result.Append(card);
                    result.Append(" ");
                }

                result.Remove(result.Length - 1, 1);
                return result.ToString();    
            }
            else
            {
                return string.Empty;
            }
            
        }
    }
}
