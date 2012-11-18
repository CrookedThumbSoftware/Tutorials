/**
 * @file   Program.cs
 * @Author Frank Swehosky (Frank@CrookedThumbSoftware.com)
 * @date   November 2012
 * @brief  Illustrate looping with a Mandelbrot set
 * Copyright (c) 2012, Crooked Thumb Software, All rights reserved.
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch4Tutorial1
{
    /**
     * Initial class of launched program
     */
    class Program
    {
        static void Main(string[] args)
        {
            //For each imaginary coordinate[1.2,-1.2], stepping 0.05
            for (double iPart = 1.2; iPart >= -1.2; iPart -= 0.05)
            {
                //For each real coordinate [-0.6, 1.77], stepping 0.03
                for (double realPart = -0.6; realPart <= 1.77; realPart += 0.03)
                {
                    int iterationCount = 0;
                    //Real temp starts as the real part for each coordinate
                    double rTemp = realPart;
                    //Imaginary temp starts as the imaginary part for each coordinate
                    double iTemp = iPart;
                    //Argument is r^2 + i^2
                    double arg = (realPart * realPart) + (iPart * iPart);

                    while ((arg < 4) && (iterationCount < 40))
                    {
                        //Calculate the next real temp
                        double rHold = (rTemp * rTemp) - (iTemp * iTemp) - realPart;
                        //Calculate the next imaginary temp, using the previous real temp
                        iTemp = (2 * rTemp * iTemp) - iPart;
                        //Update the real temp
                        rTemp = rHold;
                        //Argument is r^2 + i^2
                        arg = (rTemp * rTemp) + (iTemp * iTemp);
                        ++iterationCount;
                    }
                    //Write one character for the results of the calculations
                    switch (iterationCount % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                        //No need for default case, since %4 only has 4 cases, and they're all covered
                    }
                }
                //After each line of real coordinates, go to the next line
                Console.Write("\n");
            }
            //Keep displaying it until the user presses a key
            Console.ReadKey();
        }
    }
}
