/**
 * @file   Deck.cs
 * @Author Frank Swehosky (Frank@CrookedThumbSoftware.com)
 * @date   November 2012
 * @brief  A class to hold a complete 52 deck of cards
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
     * Each instance is an ordered deck of 54 cards
     */
    public class Deck
    {
        /**
         * Ordered Array of cards
         */
        private Cards m_cards = new Cards();
        public const int SIZE_OF_DECK = 54; //52 cards + 2 jokers

        public Deck()
        {
            //Add the cards in order in suits
            for (Suit suit = Suit.CLUB; suit < Suit.JOKER; suit++)
            {
                for (Rank rank = Rank.ACE; rank < Rank.JOKER; rank++)
                {
                    m_cards.Add(new Card(suit, rank));
                }
            }
            //Add the Jokers
            m_cards.Add(new Card(Suit.JOKER, Rank.JOKER));
            m_cards.Add(new Card(Suit.JOKER, Rank.JOKER));
        }

        public Deck(bool isAceHigh) : this()
        {
            Card.s_isAceHigh = isAceHigh;
        }

        public Deck(bool useTrumps, Suit trump) : this()
        {
            Card.s_useTrumps = useTrumps;
            Card.s_trumpSuit = trump;
        }

        public Deck(bool isAceHigh, bool useTrumps, Suit trump) : this()
        {
            Card.s_isAceHigh = isAceHigh;
            Card.s_useTrumps = useTrumps;
            Card.s_trumpSuit = trump;
        }
        public Card GetCard(int index)
        {
            if ((index >= 0) && (index < m_cards.Count))
            {
                return m_cards[index];
            }
            else
            {
                string message = "Value must be in the range [0,"+ m_cards.Count+")";
                throw (new System.ArgumentOutOfRangeException("index", index, message));
                //No return because there is a thrown exception
            }
        }

        public void Shuffle()
        {
            //The temporary deck
            Cards shuffledDeck = new Cards();
            //Whether the card at index has already been added to the temporary deck
            bool[] assigned = new bool[m_cards.Count];

            Random r = new Random();
            for (int index = 0; index < m_cards.Count; index++)
            {
                int picked = -1;
                bool available = false;
                //Loop until an available card index is picked,
                // inefficient but simple and not problematic due to limited size of range
                while (!available)
                {
                    //Get a random number in the range [0,SIZE_OF_DECK)
                    picked = r.Next(SIZE_OF_DECK);
                    available = !assigned[picked];
                }
                assigned[picked] = true;
                shuffledDeck.Add(m_cards[picked]);
            }

            //replace the ordered deck with the shuffled deck
            shuffledDeck.CopyTo(m_cards);
        }
    }
}
