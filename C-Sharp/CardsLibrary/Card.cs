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
        /**
         * The class flag for trump usage.  If true, the trump suit is valued
         * higher than cards of other suits
         */
        public static bool s_useTrumps = false;

        /**
         * The suit used as a trump, when \ref m_useTrumps is true
         */
        public static Suit s_trumpSuit = Suit.CLUB;
        /**
         * True if the ace is higher than \ref Rank.KING, false if lower than 
         * \ref Rank.TWO
         */
        public static bool s_isAceHigh = true;
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
        public static bool operator ==(Card card1, Card card2)
        {
            return (card1.m_suit == card2.m_suit) && (card1.m_rank == card2.m_rank);
        }

        public static bool operator !=(Card card1, Card card2)
        {
            return (card1.m_suit != card2.m_suit) || (card1.m_rank != card2.m_rank);
        }

        public static bool operator>(Card card1, Card card2)
        {
            if (card1.m_suit == card2.m_suit)
            {
                if (s_isAceHigh)
                {
                    if (Rank.ACE == card1.m_rank)
                    {
                        if (Rank.ACE == card2.m_rank)
                            return false;
                        else
                            return true;
                    }
                    else //if card1 not an ace
                    {
                        if (Rank.ACE == card2.m_rank)
                            return false;
                        else
                            return (card1.m_rank > card2.m_rank);
                    }
                }
                else // if not aceHigh
                {
                    return (card1.m_rank > card2.m_rank);
                }
            }
            else {
                //Since the suits don't match, only trumps matter
                //Is the second card a trump?
                if ((s_useTrumps) && (card2.m_suit == s_trumpSuit))
                    return false;
                else 
                    return true;
            } 
        }// operator>()
        
        public static bool operator >=(Card card1, Card card2)
        {
            if (card1.m_suit == card2.m_suit)
            {
                if (s_isAceHigh)
                {
                    if (Rank.ACE == card1.m_rank)
                    {
                        return true;
                    }
                    else
                    {
                        if (Rank.ACE == card2.m_rank)
                        {
                            return false;
                        }
                        else
                        {
                            return (card1.m_rank >= card2.m_rank);
                        }
                    }
                }
                else
                {
                    return (card1.m_rank >= card2.m_rank);
                }
            }
            else
            {
                //Since the suits don't match, only trumps matter
                //Is the second card a trump?
                if ((s_useTrumps) && (card2.m_suit == s_trumpSuit))
                    return false;
                else
                    return true;
            }
        } //operator >=

        public static bool operator<=(Card card1, Card card2)
        {
            return !(card1 > card2);
        }

        public static bool operator<(Card card1, Card card2)
        {
            return !(card1 >= card2);
        }

        public override bool Equals(object card)
        {
            return this == (Card)card;
        }

        public override int GetHashCode()
        {
            return 13 * (int)m_rank + (int)m_suit;
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
