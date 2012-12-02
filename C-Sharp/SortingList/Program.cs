/**
 * @file   Program.cs
 * @Author Frank Swehosky (Frank@CrookedThumbSoftware.com)
 * @date   December 2012
 * @brief  Sorting test using IComparable and IComparer
 * Copyright (c) 2012, Crooked Thumb Software, All rights reserved.
 * 
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingList
{
    class Person : IComparable
    {
        public string m_name;
        public int m_age;

        public Person(string name, int age)
        {
            m_name = name;
            m_age = age;
        }

        /**
         * Implements the IComparable function
         */
        public int CompareTo(object obj)
        {
            //Only other Person objects are a valid comparison for an instance
            if (obj is Person)
            {
                Person other = obj as Person;
                return this.m_age - other.m_age;
            }
            else
            {
                throw new ArgumentException("Object to compare to is not a Person object.");
            }
        }
    }

    class PersonComparerName : IComparer
    {
        public static IComparer Default = new PersonComparerName();

        /**
         * Implements the IComparer function
         */
        public int Compare(object x, object y)
        {
            //This compare is only valid for Person objects
            if ((x is Person) && (y is Person))
            {
                return Comparer.Default.Compare(((Person)x).m_name, ((Person)y).m_name);
            }
            else
            {
                throw new ArgumentException("One or both objects to compare are not Person objects.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add (new Person("Dale", 65));
            list.Add(new Person("Kristi", 90));
            list.Add(new Person("Quinnlyn", 2));
            list.Add(new Person("Kori", 34));
            list.Add(new Person("Frank", 35));

            Console.WriteLine("Unsorted people:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0} ({1})", (list[i] as Person).m_name,
                    (list[i] as Person).m_age);
            }
            Console.WriteLine();

            list.Sort();
            Console.WriteLine("People sorted by age (with default comparer):");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0} ({1})", (list[i] as Person).m_name,
                    (list[i] as Person).m_age);
            }
            Console.WriteLine();

            list.Sort(PersonComparerName.Default);
            Console.WriteLine("People sorted by name (with non-default comparer):");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0} ({1})", (list[i] as Person).m_name,
                    (list[i] as Person).m_age);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
