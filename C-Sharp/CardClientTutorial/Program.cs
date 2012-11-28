/**
 * @file   Program.cs
 * @Author Frank Swehosky (Frank@CrookedThumbSoftware.com)
 * @date   November 2012
 * @brief  A tutorial example showing use of the cards library
 * Copyright (c) 2012, Crooked Thumb Software, All rights reserved.
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardsLibrary;

namespace CardClientTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();
            for (int i = 0; i < Deck.SIZE_OF_DECK; i++)
            {
                Card oneCard = deck.GetCard(i);
                Console.Write(oneCard.ToString());
                if (i < (Deck.SIZE_OF_DECK - 1))
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
