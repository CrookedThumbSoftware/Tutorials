/**
 * @file   Program.cs
 * @Author Frank Swehosky (Frank@CrookedThumbSoftware.com)
 * @date   November 2012
 * @brief  Explores enums and structs
 * Copyright (c) 2012, Crooked Thumb Software, All rights reserved.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch5Tutorial1
{

    /**
     * The enumeration is for the cardinal directions, so is less than 256 elements and can be contained within
     * a single byte.
     */
    enum Orientation: byte
    {
        INVALID_ORIENTATION,    /** An invalid orientation */
        NORTH,                  /** North direction */
        SOUTH,                  /** South direction */
        EAST,                   /** East direction */
        WEST,                   /** West direction */
        MAX_ORIENTATION         /** Maximum orientation, allows for easy iteration */
    }
    /**
     * The structure to hold a direction and distance
     */
    struct DirectionStep
    {
        public Orientation direction;   /** The direction to go */
        public double distance;         /** The distance to travel */
    }
    /**
     * The initial class for default execution
     */
    class Program
    {
        static void Main(string[] args)
        {
            DirectionStep route;
            int direction = -1;  //Initialize with an invalid direction
            double distance = 0.0;
            String input = "";

            //Write out possibilities to the user
            for (Orientation o = Orientation.NORTH; o < Orientation.MAX_ORIENTATION; o++)
            {
                Console.WriteLine("{0}) {1}", (byte)o, o.ToString());
            }

            //Keep reading user input until they input a valid orientation
            do
            {
                Console.WriteLine("Please select a numerical direction:");
                try
                {
                    input = Console.ReadLine();
                    direction = Convert.ToInt32(input);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("{0} is outside the range.", input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("The input '{0}' is not a valid int.", input);
                }

            } while ((direction <= (int)Orientation.INVALID_ORIENTATION) || (direction >= (int)Orientation.MAX_ORIENTATION));

            //Keep reading user input until they input a valid distance
            bool okay = false;
            do
            {
                Console.WriteLine("Please select a distance:");
                try
                {
                    input = Console.ReadLine();
                    distance = Convert.ToDouble(input);
                    okay = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("{0} is outside the range of a double.", input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("The input '{0}' is not a valid double.", input);
                }

            } while (!okay);

            route.direction = (Orientation)direction;
            route.distance = distance;

            Console.WriteLine("Variable route specifies a direction of {0} and a distance of {1}.",
                route.direction.ToString(), route.distance);

            //Wait for user input
            Console.ReadKey();
        }
    }
}
