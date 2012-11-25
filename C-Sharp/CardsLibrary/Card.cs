/**
 * @file   Card.cs
 * @Author Frank Swehosky (Frank@CrookedThumbSoftware.com)
 * @date   November 2012
 * @brief  Defines a card object
 * Copyright (c) 2012, Crooked Thumb Software, All rights reserved.
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardsLibrary
{
    /**
     * Defines a standard 54-card class
     */
    public class Card
    {
        public readonly Rank m_rank;
        public readonly Suit m_suit;

        private Card()
        {
            throw new System.NotImplementedException();
        }

        public Card(Suit suit, Rank rank)
        {
            m_suit = suit;
            m_rank = rank;
        }

        public override String ToString()
        {
            if (Rank.JOKER != m_rank)
            {
                return "The " + m_rank + " of " + m_suit + "s";
            }
            else
            {
                return "The " + m_rank;
            }
        }
    }
}
