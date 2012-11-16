/**
 * @file   Program.cs
 * @Author Frank Swehosky (Frank@CrookedThumbSoftware.com)
 * @date   November 2012
 * @brief  Chapter 3, tutorial 2: manipulating variables and console input
 * Copyright (c) 2012, Crooked Thumb Software, All rights reserved.
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch3Tutorial2
{
    /**
     * The default program to launch with the console app
     */
    class Program
    {
        static void Main(string[] args)
        {
            //Get the user's name 
            string name;
            Console.WriteLine("Please enter your name:");
            name = Console.ReadLine();

            double first = 0.0, second = 0.0;
            string input;
            Console.WriteLine("Welcome {0}!", name);
            //Loop until the user provides a valid number
            //  or aborts
            bool okay = false;
            do
            {
                Console.WriteLine("Please enter a number:");
                input = Console.ReadLine();
                try
                {
                    first = Convert.ToDouble(input);
                    okay = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("{0} is outside the range of the double type.", input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("The input '{0}' is not a valid double.", input);
                }
            } while (!okay);
            //Loop until the user provides a 2nd valid number
            //  or aborts
            okay = false;
            do
            {
                Console.WriteLine("Please enter another number:");
                input = Console.ReadLine();
                try
                {
                    second = Convert.ToDouble(input);
                    okay = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("{0} is outside the range of the double type.", input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("The input '{0}' is not a valid double.", input);
                }
            } while (!okay);

            Console.WriteLine("The sum of {0} and {1} is {2}.",
                first, second, (first + second));

            Console.WriteLine("The result of {0} minus {1} is {2}.",
                first, second, (first - second));

            //This is correctly interpreted as infinity if second = 0
            Console.WriteLine("The result of {0} divided by {1} is {2}.",
                first, second, (first / second));

            Console.WriteLine("The result of {0} multiplied by {1} is {2}.",
                first, second, (first * second));

            Console.WriteLine("The modulus of {0} by {1} is {2}.",
                first, second, (first % second));

            Console.ReadKey();
        }
    }
}
