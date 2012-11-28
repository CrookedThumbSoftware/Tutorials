/**
 * @file   Animal.cs
 * @Author Frank Swehosky (Frank@CrookedThumbSoftware.com)
 * @date   November 2012
 * @brief  Contains the Animal class
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
    /**
     * Abstract class animal
     */
    public abstract class Animal
    {
        protected string name; ///Name of the animal
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Animal ()
        {
            name = "Unknown animal";
        }
        public Animal (string initName)
        {
            name = initName;
        }
        public void Feed()
        {
            Console.WriteLine("{0} has been fed.", name);
        }
    }
    /**
     * Collection of animals
     */
    public class Animals : CollectionBase
    {
        public void Add(Animal animal)
        {
            List.Add(animal);
        }
        public void Remove(Animal animal)
        {
            List.Remove(animal);
        }
        public Animals()
        {

        }
        /**
         * Allow accessing random elements with [int]
         */
        public Animal this[int index]
        {
            get
            {
                if ((index < 0) || (index >= List.Count))
                {
                    string message = "Value must be in the range [0," + List.Count + ")";
                    throw (new System.ArgumentOutOfRangeException("index", index, message));
                }
                return (Animal)List[index];
            }
            set
            {
                if ((index < 0) || (index >= List.Count))
                {
                    string message = "Value must be in the range [0," + List.Count + ")";
                    throw (new System.ArgumentOutOfRangeException("index", index, message));
                }
                List[index] = value;
            }
        }
    }

}
