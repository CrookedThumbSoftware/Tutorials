/**
 * @file   Program.cs
 * @Author Frank Swehosky (Frank@CrookedThumbSoftware.com)
 * @date   November 2012
 * @brief  Examines arrays, collections, and abstract classes
 * Copyright (c) 2012, Crooked Thumb Software, All rights reserved.
 * 
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayOrCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create an Array type collection of Animal objects");
            Animal[] animalArray = new Animal[3];
            //Initialize the data of the array
            Cow tCow = new Cow("Deirdre");
            animalArray[0] = tCow;
            animalArray[1] = new Cow("Jill");
            animalArray[2] = new Chicken("Ken");

            foreach (Animal ani in animalArray)
            {
                Console.WriteLine("Animal {0}, named {1} in array", ani.ToString(), ani.Name);
            }

            Console.WriteLine("Array collection contains {0} objects", animalArray.Length);
            foreach (Animal ani in animalArray)
            {
                ani.Feed();
                if (ani is Cow)
                {
                    ((Cow)ani).Milk();
                }
                else if (ani is Chicken)
                {
                    ((Chicken)ani).LayEgg();
                }
            }
            Console.WriteLine();

            Console.WriteLine("Create an ArrayList type collection of Animal objects");
            ArrayList aniAL = new ArrayList();
            Cow tCow2 = new Cow("Harley");
            aniAL.Add(tCow2);
            aniAL.Add(new Chicken("Row"));

            foreach (Animal ani in aniAL)
            {
                Console.WriteLine("Animal {0}, named {1} in array", ani.ToString(), ani.Name);
            }
            Console.WriteLine("Array collection contains {0} objects", aniAL.Count);

            foreach (Animal ani in aniAL)
            {
                ani.Feed();
                if (ani is Cow)
                {
                    ((Cow)ani).Milk();
                }
                else if (ani is Chicken)
                {
                    ((Chicken)ani).LayEgg();
                }
            }

            ((Animal)aniAL[1]).Name = "Bob";
            Console.WriteLine("Animal {0}, named {1} in array", ((Animal)aniAL[1]).ToString(),
                ((Animal)aniAL[1]).Name);

            Console.WriteLine();

            Animals aniCollect = new Animals();
            aniCollect.Add(new Cow("FooMark"));

            foreach (Animal ani in aniCollect)
            {
                Console.WriteLine("Animal {0}, named {1} in array", ani.ToString(), ani.Name);
            }
            Console.WriteLine("Array collection contains {0} objects", aniCollect.Count);

            foreach (Animal ani in aniCollect)
            {
                ani.Feed();
                if (ani is Cow)
                {
                    ((Cow)ani).Milk();
                }
                else if (ani is Chicken)
                {
                    ((Chicken)ani).LayEgg();
                }
            }

            //Accessing an index outside the range will throw an exception
            for (int i = 0; i <= aniCollect.Count; i++)
            {
                aniCollect[i].Feed();
            }

            Console.ReadKey();
        }
    }
}
