/**
 * @file   Program.cs
 * @Author Frank Swehosky (Frank@CrookedThumbSoftware.com)
 * @date   November 2012
 * @brief  Compares class access and struct access
 * Copyright (c) 2012, Crooked Thumb Software, All rights reserved.
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassVsStruct
{
    /**
     * Test class
     */
    class Foo
    {
        public int value;
    }
    struct Bar
    {
        public int value;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new instance of the class
            Foo objectA = new Foo();
            //objectB is a reference to objectA
            Foo objectB = objectA;
            objectA.value = 10;
            objectB.value = 20;

            //Create a new instance of the structure
            Bar structA = new Bar();
            //Copy the value of structA
            Bar structB = structA;
            structA.value = 30;
            structB.value = 40;

            Console.WriteLine("objectA.value == {0}, objectB.value == {1}", objectA.value, objectB.value);
            Console.WriteLine("structA.value == {0}, structB.value == {1}", structA.value, structB.value);
            Console.ReadKey();
        }
    }
}
