/**
 * @file   Program.cs
 * @Author Frank Swehosky (Frank@CrookedThumbSoftware.com)
 * @date   November 2012
 * @brief  The initial console app.
 * Copyright (c) 2012, Crooked Thumb Software, All rights reserved.
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch3Tutorial1
{
    /**
     * The static class used for the initial call
     */
    class Program
    {
        /** 
         * <summary> The main entry point for the application.</summary>
         **/
        static void Main(string[] args)
        {
            int i = 5;
            string temp= "\"i\" is";

            //Mess with it using the unary operators inline
            i = i * --i;
            // temp = i (5)
            // i = i - 1 (4)
            // i = temp * i (5 * 4 = 20)

            //Reset and test again
            i = 5;
            i = i++ * --i;
            // temp = i (5)
            // i = i + 1 (6)
            // i = i - 1 (5)
            // i = temp * i (5 * 5 = 25)

            //Print to the console
            Console.WriteLine("{0} {1}.", temp, i);
            //Wait for the user to press a key
            Console.ReadKey();
        }
    }
}
