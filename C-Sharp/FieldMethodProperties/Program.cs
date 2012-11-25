/**
 * @file   Program.cs
 * @Author Frank Swehosky (Frank@CrookedThumbSoftware.com)
 * @date   November 2012
 * @brief  Tutorial example using Fields, Methods, and Properties of a class
 * Copyright (c) 2012, Crooked Thumb Software, All rights reserved.
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FieldMethodProperties
{
    /**
     * Example class
     */
    class Example
    {
        public readonly string m_name;
        private int m_value;
        public int Val
        {
            get
            {
                return m_value;
            }

            /**
             * Allows setting an int value [0, 10]
             * @param value The value being set
             */
            set
            {
                //If the value being set is within the appropriate range
                if ((value >= 0) && (value <= 10))
                {
                    m_value = value;
                }
                else
                {
                    throw (new ArgumentOutOfRangeException("Val", value, "Must be in the range of [0,10]"));
                }
            }
        }
        public override string ToString()
        {
            return "Name: " + m_name + "\nValue: " + m_value;   
        }

        /**
         * public constructor requires a string
         * @param name The name of the class instance
         */
        public Example(string name)
        {
            m_name = name;
            m_value = 0;
        }

        /**
         * Private constructor, only used by the class
         */
        private Example() : this("Default Name")
        {

        }
    }
    /**
     * The default program instance
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating instance of Example object");
            Example example = new Example("My Object");
            Console.WriteLine("example created.\n");

            for (int i = -1; i < 1; i++)
            {
                try
                {
                    Console.WriteLine("Attempting to assign {0} to example.Val", i);
                    example.Val = i;
                    Console.WriteLine("Value {0} assigned to example.Val", example.Val);
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nException {0} thrown.", e.GetType().FullName);
                    Console.WriteLine("Message:\n'{0}'\n", e.Message);
                }
            }
            Console.WriteLine("\nexample.ToString():");
            Console.WriteLine("'{0}'", example.ToString());
            Console.ReadKey();
        }
    }
}
