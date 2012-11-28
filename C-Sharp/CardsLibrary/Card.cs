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
using System.Collections;
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
                return m_rank + " of " + m_suit + "s";
            }
            else
            {
                return m_rank.ToString();
            }
        }
    }

    /**
     * collection class of Card
     */
    public class Cards : CollectionBase
    {
        public void Add(Card card)
        {
            List.Add(card);
        }
        public void Remove(Card card)
        {
            List.Remove(card);
        }
        public Cards()
        {
        }
        public Card this[int index]
        {
            get
            {
                return (Card)List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        /**
         * Method for copying cards into another Cards instance, like for Deck.Shuffle()
         * Assumes that source and target collections are the same size
         */
        public void CopyTo(Cards target)
        {
            for (int index = 0; index < this.Count; index++)
            {
                target[index] = this[index];
            }
        }

        /**
         * Checks to see if the collection contains a particular card, by
         * calling the ArrayList.Contains ()
         */
        public bool Contains(Card card)
        {
            return InnerList.Contains(card);
        }
    }
}
