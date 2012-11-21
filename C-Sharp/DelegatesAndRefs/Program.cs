/**
 * @file   Program.cs
 * @Author Frank Swehosky (Frank@CrookedThumbSoftware.com)
 * @date   November 2012
 * @brief  Explore function delegates and references
 * Copyright (c) 2012, Crooked Thumb Software, All rights reserved.
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesAndRefs
{
    class Program
    {
        static void OverloadTest (int value)
        {
            //Double it for the test
            value *= 2;
            Console.WriteLine("In OverloadTest, value now {0}", value);
        }
        static void OverloadTest (ref int value)
        {
            //Double it for the test
            value *= 2;
            Console.WriteLine("In OverloadTest, value now {0}", value);
        }

        delegate double ProcessDelegate(double arg1, double arg2);

        static double Multiply(double arg1, double arg2)
        {
            return arg1 * arg2;
        }
        static double Divide(double arg1, double arg2)
        {
            return arg1 / arg2;
        }
        static void Main(string[] args)
        {
            //Test overloads
            int mainVal = 10;
            Console.WriteLine("In Main, value now {0}", mainVal);
            OverloadTest(mainVal);
            Console.WriteLine("In Main, value now {0}", mainVal);
            OverloadTest(ref mainVal);
            Console.WriteLine("In Main, value now {0}", mainVal);

            //test delegates
            ProcessDelegate testDelegate;
            Console.WriteLine("Please enter two numbers, separated by a comma:");

            String input = Console.ReadLine();
            String[] numbers = input.Split(',');
            //Assume correct formatting for now
            double temp1 = Convert.ToDouble(numbers[0]);
            double temp2 = Convert.ToDouble(numbers[1]);

            testDelegate = new ProcessDelegate(Multiply);
            double temp3 = testDelegate(temp1, temp2);
            Console.WriteLine("First result of testDelegate is {0}", temp3);

            testDelegate = new ProcessDelegate(Divide);
            temp3 = testDelegate(temp1, temp2);
            Console.WriteLine("Second result of testDelegate is {0}", temp3);

            //wait for the user to press a key
            Console.ReadKey();
        }
    }
}
