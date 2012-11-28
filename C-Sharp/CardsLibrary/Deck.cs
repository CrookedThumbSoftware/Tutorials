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
        private Card[] m_cards;
        public const int SIZE_OF_DECK = 54; //52 cards + 2 jokers

        public Deck()
        {
            m_cards = new Card[SIZE_OF_DECK];
            int index = 0;
            //Add the cards in order in suits
            for (Suit suit = Suit.CLUB; suit < Suit.JOKER; suit++)
            {
                for (Rank rank = Rank.ACE; rank < Rank.JOKER; rank++)
                {
                    m_cards[index++] = new Card(suit, rank);
                }
            }
            //Add the Jokers
            m_cards[index++] = new Card(Suit.JOKER, Rank.JOKER);
            m_cards[index++] = new Card(Suit.JOKER, Rank.JOKER);
        }

        public Card GetCard(int index)
        {
            if ((index >= 0) && (index < SIZE_OF_DECK))
            {
                return m_cards[index];
            }
            else
            {
                string message = "Value must be in the range [0,"+(SIZE_OF_DECK - 1)+"]";
                throw (new System.ArgumentOutOfRangeException("index", index, message));
                //No return because there is a thrown exception
            }
        }

        public void Shuffle()
        {
            //The temporary deck
            Card[] shuffledDeck = new Card[SIZE_OF_DECK];
            //Whether the card at index has already been added to the temporary deck
            bool[] assigned = new bool[SIZE_OF_DECK];

            Random r = new Random();
            for (int index = 0; index < SIZE_OF_DECK; index++)
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
                shuffledDeck[index] = m_cards[picked];
            }

            //replace the ordered deck with the shuffled deck
            shuffledDeck.CopyTo(m_cards, 0);
        }
    }
}
